using RestOrderingClases;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Registro
{
    public partial class RegPlatoRest : Form
    {
        private Plato[] platos;
        private PlatoRestaurante[] platosRestaurante;
        private Restaurante[] restaurantes;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public RegPlatoRest()
        {
            InitializeComponent();
            SetLanguage();
            panelErrorRest.Visible = false;
            panelerrorplato.Visible = false;
            CargarArrays();
            if (restaurantes == null || restaurantes.Length == 0) //revisa si existen restaurantes
            {
                buttonAso.Enabled = false; //no existen, por lo que no permite continuar
                panelErrorRest.Visible = true;
                labelError.Text = manager.GetString("regPlatoRest_ErrorNoRest"); //mensaje de no hay restaurante
            }
            else //si hay restaurantes
            {
                llenarcomboboxRest(); //llena la lista de restaurantes disponibles
                if (platos == null || platos.Length == 0) //revisa si hay platos para asociar
                {
                    buttonAso.Enabled = false;//no hay, no permite continuar
                    panelerrorplato.Visible = true;
                    labelErrorPlat.Text = manager.GetString("regPlatoRest_ErrorNoPlat");
                }
                else if (platosRestaurante == null)
                {
                    buttonAso.Enabled = false;
                }
            }
        }

        private void SetLanguage()
        {
            SelectorLenguaje sl = new SelectorLenguaje();
            manager = sl.CargarLenguaje();
            label1.Text = manager.GetString("regPlatoRest_titulo");
            label2.Text = manager.GetString("regPlatoRest_instrucciones");
            label3.Text = manager.GetString("regPlatoRest_platos");
            label4.Text = manager.GetString("regPlatoRest_platosAso");
            label7.Text = manager.GetString("regPlatoRest_restaurante");
            buttonAso.Text = manager.GetString("regPlatoRest_asociar");
        }

        /// <summary>
        /// Obtiene array Platos, Restaurantes y PlatoRestaurante de la DB
        /// </summary>
        private void CargarArrays()
        {
            buttonAso.Enabled = false;
            panelErrorRest.Visible = true;
            labelError.Text = manager.GetString("reg_Cargando");
            platos = Program.datosSQL.ObtenerPlatos();
            restaurantes = Program.datosSQL.ObtenerRestaurantes();
            platosRestaurante = Program.datosSQL.ObtenerPlatoRest(restaurantes, platos);
            panelErrorRest.Visible = false;

            buttonAso.Enabled = true;
        }

        /// <summary>
        /// Llena el combobox con los restaurantes disponibles
        /// </summary>
        private void llenarcomboboxRest()
        {
            foreach (Restaurante rest in restaurantes)
            {
                if (rest != null && rest.Estado == true)
                {
                    string reststring = rest.ID.ToString() + " - " + rest.Nombre + " - " + rest.Direccion;
                    comboBoxRest.Items.Add(reststring);
                }
            }
        }

        /// <summary>
        /// Cargar Las tablas segun el restaurante seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxRest_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarTablaPlatosAsociados();// llena la tabla de platos Ya asociados anteriormente
            llenartabla(); //llena la tabla de platos para asociar
        }

        /// <summary>
        /// Obtiene el restaurante selccionado en el combobox
        /// </summary>
        /// <returns>
        /// Objeto Restaurante
        /// </returns>
        private Restaurante restseleccionado()
        {
            if (comboBoxRest.SelectedItem == null)
            {
                return null;
            }

            string itemseleccionado = comboBoxRest.SelectedItem.ToString(); // convierte a string el item seleccionado
            int IndexSeparador = itemseleccionado.IndexOf(" - "); // encuentra el index de la primera ocurrencia de  " - "

            if (IndexSeparador != -1) // asegura que haya encontrado el patron " - "
            {
                string idString = itemseleccionado.Substring(0, IndexSeparador).Trim(); // extrae la id de la string
                if (int.TryParse(idString, out int id)) // convierte a int la id
                {
                    foreach (Restaurante rest in restaurantes)
                    {
                        if (rest != null && rest.ID == id)
                        {
                            return rest;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Llena la tabla con los Platos disponibles
        /// </summary>
        private void llenartabla()
        {
            dataGridView.Rows.Clear();
            dataGridView.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnCount = 4;
            dataGridView.Columns[0].Name = manager.GetString("Columna_IDPlato");
            dataGridView.Columns[1].Name = manager.GetString("Columna_NombrePlato");
            dataGridView.Columns[2].Name = manager.GetString("Columna_Precio");
            dataGridView.Columns[3].Name = manager.GetString("Columna_Categoria");

            Restaurante RestauranteSeleccionado = restseleccionado(); //obtiene el restaurante selccionado

            if (RestauranteSeleccionado != null)
            {
                foreach (Plato plat in platos)
                {
                    if (plat != null && !PlatoEstaAsociado(plat, RestauranteSeleccionado))//agrega cada plato que no esta asociado con el restaurante
                    {
                        string[] fila = new string[] { plat.ID.ToString(), plat.Nombre, plat.Precio.ToString(), plat.Categoria.ID.ToString() };
                        dataGridView.Rows.Add(fila);
                    }
                }
            }

            //agrega un check box para seleccionar los platos
            DataGridViewCheckBoxColumn checkBoxColumna = new DataGridViewCheckBoxColumn();
            checkBoxColumna.Name = manager.GetString("Columna_Seleccionar");
            dataGridView.Columns.Add(checkBoxColumna);

            foreach (DataGridViewColumn columna in dataGridView.Columns) //hace que todo sea Read only menos el checkbox
            {
                if (columna != checkBoxColumna)
                {
                    columna.ReadOnly = true;
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        /// <summary>
        /// Verifica si el plato seleccionado ya esta asociado o no con el restaurante
        /// </summary>
        /// <param name="plato"></param>
        /// <param name="restaurante"></param>
        /// <returns></returns>
        private bool PlatoEstaAsociado(Plato plato, Restaurante restaurante)
        {
            foreach (PlatoRestaurante registro in platosRestaurante)
            {
                if (registro != null && registro.Restaurante.ID == restaurante.ID)
                {
                    foreach (Plato asociado in registro.Platos)
                    {
                        if (asociado != null && asociado.ID == plato.ID)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Obtiene un Array con los Platos seleccionados
        /// </summary>
        /// <returns></returns>
        private Plato[] platosseleccionados()
        {
            Plato[] PlatosSeleccionados = new Plato[10]; //array para almacenar los platos, max 10
            int SeleccionadosCuenta = 0;

            foreach (DataGridViewRow fila in dataGridView.Rows)//revisa cada fila de la tabla 
            {
                DataGridViewCheckBoxCell checkBoxCell = fila.Cells[manager.GetString("Columna_Seleccionar")] as DataGridViewCheckBoxCell; //copia la columna de seleccion

                if (checkBoxCell.Value != null && (bool)checkBoxCell.Value) // revisa el valor de selccion
                {
                    int id = Convert.ToInt32(fila.Cells[manager.GetString("Columna_IDPlato")].Value); //si esta seleccionado, toma el id del plato
                    foreach (Plato plat in platos) //busca y guarda el plato en el array
                    {
                        if (plat != null && plat.ID == id)
                        {
                            PlatosSeleccionados[SeleccionadosCuenta] = plat;
                            SeleccionadosCuenta++;

                            if (SeleccionadosCuenta >= 10)
                                break;
                        }
                    }

                    if (SeleccionadosCuenta >= 10)
                        break;
                }
            }
            Array.Resize(ref PlatosSeleccionados, SeleccionadosCuenta);
            return PlatosSeleccionados; //devuelve el array
        }

        /// <summary>
        /// Llena la tabla con los platos ya asociados
        /// </summary>
        private void LlenarTablaPlatosAsociados()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].Name = manager.GetString("Columna_IDPlato");
            dataGridView2.Columns[1].Name = manager.GetString("Columna_NombrePlato");
            dataGridView2.Columns[2].Name = manager.GetString("Columna_Precio");
            dataGridView2.Columns[3].Name = manager.GetString("Columna_Categoria");

            Restaurante RestauranteSeleccionado = restseleccionado();

            if (RestauranteSeleccionado != null)
            {
                foreach (PlatoRestaurante registro in platosRestaurante) //busca los registros del restuarante seleccionado y sus platos asociados
                {
                    if (registro != null && registro.Restaurante.ID == RestauranteSeleccionado.ID)
                    {
                        foreach (Plato plat in registro.Platos)
                        {
                            if (plat != null)
                            {
                                string[] row = new string[] { plat.ID.ToString(), plat.Nombre, plat.Precio.ToString(), plat.Categoria.ID.ToString() };
                                dataGridView2.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            foreach (DataGridViewColumn columna in dataGridView2.Columns) //hace que todo sea Read only menos el checkbox
            {
                    columna.ReadOnly = true;
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        /// <summary>
        /// Cuenta cuantos platos fueron seleccionados
        /// </summary>
        /// <returns></returns>
        private int PlatosSeleccionadosCuenta()
        {
            int SeleccionadoCuenta = 0;

            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCasilla = fila.Cells[manager.GetString("Columna_Seleccionar")] as DataGridViewCheckBoxCell;

                if (checkBoxCasilla.Value != null && (bool)checkBoxCasilla.Value)
                {
                    SeleccionadoCuenta++;
                }
            }

            return SeleccionadoCuenta;
        }

        /// <summary>
        /// Genera una nueva Id de Asignacion para el Registro
        /// </summary>
        /// <returns></returns>
        private int GenerarNuevaIdAsignacion()
        {
            int maxIdAsignacion = 0;

            foreach (var platoRest in platosRestaurante)
            {
                if (platoRest.Id_asignacion > maxIdAsignacion)
                {
                    maxIdAsignacion = platoRest.Id_asignacion;
                }
            }

            int nuevaIdAsignacion = maxIdAsignacion + 1;

            return nuevaIdAsignacion;
        }

        /// <summary>
        /// Crea objeto PlatoRestaurante y lo envia para registrar en DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReg_Click(object sender, EventArgs e)
        {
            int PlatosSeleccionadosCuenta = this.PlatosSeleccionadosCuenta();

            //veirifa que se haya seleccionado un plato
            if (PlatosSeleccionadosCuenta == 0)
            {
                MessageBox.Show($"{manager.GetString("regPlatoRest_M1_info")}", $"{manager.GetString("regPlatoRest_M1_tipo")}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //si se seleccionaron mas de 10 platos muestra advetencia, debe selecionar menos
            if (PlatosSeleccionadosCuenta > 10)
            {
                MessageBox.Show($"{manager.GetString("regPlatoRest_M2_info")}", $"{manager.GetString("regPlatoRest_M2_tipo")}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //si se seleccionaron menos de 10 platos pregunta si desea agregar más
            else if (PlatosSeleccionadosCuenta < 10)
            {
                DialogResult result = MessageBox.Show($"{manager.GetString("regPlatoRest_M3_info1")} {PlatosSeleccionadosCuenta} {manager.GetString("regPlatoRest_M3_info2")}", $"{manager.GetString("regPlatoRest_M3_tipo")}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    return;
            }

            //si selecciono 10 platos exactos, pregunta si está seguro de su seleccion, dando opcion para cambiar algun plato
            else if (PlatosSeleccionadosCuenta == 10)
            {
                DialogResult result = MessageBox.Show($"{manager.GetString("regPlatoRest_M4_info")}", $"{manager.GetString("regPlatoRest_M4_tipo")}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
            }

            Plato[] selectedPlatos = platosseleccionados();//Optiene los platos seleccionados
            Restaurante selectedRestaurante = restseleccionado(); //optiene el restaurante seleccionado

            int idAsig = GenerarNuevaIdAsignacion();
            PlatoRestaurante platorest = new PlatoRestaurante(idAsig, selectedRestaurante, DateTime.Now, selectedPlatos); //Crea el objeto
            Program.datosSQL.agregarplatorest(platorest); //lo registra

            MessageBox.Show($"{manager.GetString("regPlatoRest_M5_info")}", $"{manager.GetString("regPlatoRest_M5_tipo")}", MessageBoxButtons.OK, MessageBoxIcon.Information); //muestra mesaje de confirmacion

            //limpia el formulario
            CargarArrays();
            llenartabla(); // Llena la tabla de platos para asociar
            LlenarTablaPlatosAsociados(); // Llena la tabla de platos ya asociados anteriormente

        }

    }
}

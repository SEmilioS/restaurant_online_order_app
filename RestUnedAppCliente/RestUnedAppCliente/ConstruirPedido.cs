using RestUnedClases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RestUnedAppCliente.Server.Client;

namespace RestUnedAppCliente.Formularios.Registrar
{
    public partial class ConstruirPedido : Form
    {
        //variables de datos
        private Plato[] platos;
        private PlatoRestaurante[] platosRestaurante;
        private Restaurante[] restaurantes;
        private Extra[] extras;

        //Variables finales (producto Pedido)
        private Pedido PedidoConstruido;
        private List<ExtraPedido> exPedido = new List<ExtraPedido>();

        //Variables de construccion (Para crear Pedido)
        private Plato platoExtraseleccionado;
        private int IdPedido = 1;
        private Restaurante RestauranteSeleccionado;
        private List<Plato> PlatosSeleccionados = new List<Plato>();
        public ConstruirPedido()
        {
            InitializeComponent();
            panelErrorRest.Visible = false;
            labelnoseleccion.Visible = false;
            panelErrorReg.Visible = false;
            panelerrorplato.Visible = false;
            Program.pedido = null;
            Program.PedidoPendiente = false;
            SolicitarInformacion("Restaurantes");
            if (restaurantes == null || restaurantes.Length == 0) //revisa si existen restaurantes
            {
                buttonAso.Enabled = false; //no existen, por lo que no permite continuar
                panelErrorRest.Visible = true;
                labelcargando.Visible = true;
            }
            else //si hay restaurantes
            {
                llenarcomboboxRest(); //llena la lista de restaurantes disponibles
            }
        }

        /// <summary>
        /// Reliza Solicitudes al servidor segun el tipo
        /// </summary>
        /// <param name="tipo"></param>
        private void SolicitarInformacion(string tipo) //realiza request al servidor 
        {
            Client client = new Client();
            buttonAso.Enabled = false;
            panelErrorRest.Visible = true;
            labelcargando.Visible = true;
            switch (tipo)
            {
                case "Restaurantes":
                    restaurantes = client.SolicitarRestaurantes();
                    break;
                case "PlatoRest":
                    platosRestaurante = client.SolicitarPlatoRest();
                    break;
                case "Extras":
                    extras = client.SolicitarExtras();
                    break;
                case "Platos":
                    platos = client.SolicitarPlatos();
                    break;
                default:
                    break;
            }
            panelErrorRest.Visible = false;
            labelcargando.Visible = false;
            buttonAso.Enabled = true;
            client.CloseConnection();
        }

        /// <summary>
        /// Llena combobox de Restaurantes
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
        /// Detecta si se selecciono un Restaurante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxRestaurante_seleccionado(object sender, EventArgs e) //Carga las tablas segun el restaurante seleccionado
        {
            //limpia variables antes de iniciar
            exPedido.Clear();
            PlatosSeleccionados.Clear();
            RestauranteSeleccionado = restseleccionado(); //obtiene el restaurante selccionado
            if (platosRestaurante == null) { SolicitarInformacion("PlatoRest"); }
            if (platosRestaurante == null || platosRestaurante.Length == 0) //revisa si existen registros
            {
                buttonAso.Enabled = false; //no existen, por lo que no permite continuar
                panelErrorRest.Visible = true;
                labelnoseleccion.Visible = false;
                labelcargando.Visible = true;
                return;
            }
            if (platos == null) { SolicitarInformacion("Platos"); }
            if (platos == null || platos.Length == 0) //revisa si existen registros
            {
                buttonAso.Enabled = false; //no existen, por lo que no permite continuar
                panelErrorRest.Visible = true;
                labelnoseleccion.Visible = false;
                labelcargando.Visible = true;
                return;
            }
            llenartablaPlatos(RestauranteSeleccionado); //llena la tabla de platos para asociar
        }

        /// <summary>
        /// Obtiene objecto Restaurante con el restaurante seleccionado
        /// </summary>
        /// <returns></returns>
        private Restaurante restseleccionado() //obtiene y devuelve el restaurante seleccionado
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
                    foreach (Restaurante rest in restaurantes) // busca el restuarante
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
        /// Llena la tabla con los platos asosciados al restaurante selecionado
        /// </summary>
        /// <param name="rest"></param>
        private void llenartablaPlatos(Restaurante rest)
        {
            dataGridViewPlatos.Rows.Clear();
            dataGridViewPlatos.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridViewPlatos.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewPlatos.ColumnCount = 4;
            dataGridViewPlatos.Columns[0].Name = "Id del plato";
            dataGridViewPlatos.Columns[1].Name = "Nombre del plato";
            dataGridViewPlatos.Columns[2].Name = "Precio";
            dataGridViewPlatos.Columns[3].Name = "Categoría";

            Restaurante selectedRestaurante = restseleccionado(); //obtiene el restaurante selccionado

            if (selectedRestaurante != null)
            {
                foreach (PlatoRestaurante pr in platosRestaurante)
                {
                    if (pr != null && pr.Restaurante.ID == rest.ID)
                    {
                        foreach (Plato plat in pr.Platos)
                        {
                            if (plat != null)//agrega cada plato que no esta asociado con el restaurante
                            {
                                string[] fila = new string[] { plat.ID.ToString(), plat.Nombre, plat.Precio.ToString(), plat.Categoria.ID.ToString() };
                                dataGridViewPlatos.Rows.Add(fila);
                            }
                        }
                    }
                }
            }

            //agrega un check box para seleccionar los platos
            DataGridViewCheckBoxColumn checkBoxColumna = new DataGridViewCheckBoxColumn();
            checkBoxColumna.Name = "Seleccionar";
            dataGridViewPlatos.Columns.Add(checkBoxColumna);

            foreach (DataGridViewColumn columna in dataGridViewPlatos.Columns) //hace que todo sea Read only menos el checkbox
            {
                if (columna != checkBoxColumna)
                {
                    columna.ReadOnly = true;
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        /// <summary>
        /// Permite evitar errores de deteccion de la columna Seleccionar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewPlatos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewPlatos.IsCurrentCellDirty)
            {
                dataGridViewPlatos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Detecta selecciones en la tabla de platos y crea registros para cada seleccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewPlatos_CellContentClick(object sender, DataGridViewCellEventArgs e)//el ususario selecciono un plato
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Check for valid cell
            {
                DataGridViewCheckBoxCell checkBoxCasilla = dataGridViewPlatos.Rows[e.RowIndex].Cells["Seleccionar"] as DataGridViewCheckBoxCell;

                try
                {
                    if (checkBoxCasilla.Value != null && (bool)checkBoxCasilla.Value || !(bool)checkBoxCasilla.Value)
                    {
                        PlatosSeleccionados = platosseleccionados_tabla();
                        //por cada plato verifica si tiene un registro de extras
                        foreach (Plato pl in PlatosSeleccionados)
                        {
                            ExtraPedido existeReg = exPedido.FirstOrDefault(exi => exi.Plato.ID == pl.ID);
                            if (existeReg != null) // si no tiene lo crea
                            {
                                Extra[] extrasvacio = new Extra[0];
                                ExtraPedido nuevoexP = new ExtraPedido(IdPedido, pl, extrasvacio);
                                exPedido.Add(nuevoexP);
                            }
                        }
                        //Verificar que los registros de extras no contienen platos no seleccionados
                        List<ExtraPedido> PlatosListaNegra = new List<ExtraPedido>();
                        foreach (ExtraPedido exP in exPedido)
                        {
                            // Si un existe un registro de un plato que no está seleccionado se agrega a la lista negra
                            if (!PlatosSeleccionados.Contains(exP.Plato))
                            {
                                PlatosListaNegra.Add(exP);
                            }
                        }
                        foreach (ExtraPedido exP in PlatosListaNegra)
                        {
                            exPedido.Remove(exP);//se eliminan los registros de platos no seleccionados
                        }
                        llenarcomboboxPlatos(PlatosSeleccionados.ToArray());
                    }
                }
                catch
                {
                    Console.WriteLine("Error al detetar, celda seleccionada");
                }
            }
        }

        /// <summary>
        /// Obtiene los platos que fueron seleccionados en la tabla
        /// </summary>
        /// <returns></returns>
        private List<Plato> platosseleccionados_tabla()
        {
            List<Plato> PlatosSeleccionados = new List<Plato>();

            foreach (DataGridViewRow fila in dataGridViewPlatos.Rows) // revisa cada fila de la tabla
            {
                DataGridViewCheckBoxCell checkBoxCasilla = fila.Cells["Seleccionar"] as DataGridViewCheckBoxCell; // copia la columna de seleccion

                if (checkBoxCasilla.Value != null && (bool)checkBoxCasilla.Value) // revisa el valor de selccion
                {
                    int id = Convert.ToInt32(fila.Cells["Id del plato"].Value); // si esta seleccionado, toma el id del plato

                    foreach (Plato plat in platos) // busca y guarda el plato en la lista
                    {
                        if (plat != null && plat.ID == id)
                        {
                            PlatosSeleccionados.Add(plat);
                            break;
                        }
                    }
                }
            }
            return PlatosSeleccionados; // devuelve la lista de platos seleccionados
        }

        /// <summary>
        /// Llena el combobox de platos disponibles para agregar extras
        /// </summary>
        /// <param name="platos"></param>
        private void llenarcomboboxPlatos(Plato[] platos)
        {
            comboBoxPlatos.Items.Clear();
            foreach (Plato plat in platos)
            {
                if (plat != null)
                {
                    string platstring = plat.ID.ToString() + " - " + plat.Nombre;
                    comboBoxPlatos.Items.Add(platstring);
                }
            }
        }

        /// <summary>
        /// Detecta la seleccion de un plato para extras y llena la tabla de extras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPlatos_seleccionado(object sender, EventArgs e)
        {
            platoExtraseleccionado = PlatoSeleccionado_comboBox();
            if (extras == null) { SolicitarInformacion("Extras"); }
            if (extras == null) //revisa si existen registros nulos (error en DBsql)
            {
                buttonAso.Enabled = false; //no existen, por lo que no permite continuar
                panelErrorRest.Visible = true;
                labelnoseleccion.Visible = false;
                labelcargando.Visible = true;
                return;
            }
            else if (extras.Length == 0)
            {
                //no muestra error, simplemente no existen extras disponibles
                return;
            }
            LlenarTablaExtras(platoExtraseleccionado);
        }

        /// <summary>
        /// Obtiene el Plato seleccionado en el combobox
        /// </summary>
        /// <returns></returns>
        private Plato PlatoSeleccionado_comboBox() //obtiene y devuelve el plato seleccionado
        {
            if (comboBoxPlatos.SelectedItem == null)
            {
                return null;
            }

            string itemseleccionado = comboBoxPlatos.SelectedItem.ToString(); // convierte a string el item seleccionado
            int IndexSeparador = itemseleccionado.IndexOf(" - "); // encuentra el index de la primera ocurrencia de  " - "

            if (IndexSeparador != -1) // asegura que haya encontrado el patron " - "
            {
                string idString = itemseleccionado.Substring(0, IndexSeparador).Trim(); // extrae la id de la string
                if (int.TryParse(idString, out int id)) // convierte a int la id
                {
                    foreach (PlatoRestaurante pr in platosRestaurante)
                    {
                        if (pr != null)
                        {
                            foreach (Plato plat in pr.Platos) // busca el restuarante
                            {
                                if (plat != null && plat.ID == id)
                                {
                                    return plat;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Llena la tabla de extras segun la categoria del plato seleccionado
        /// </summary>
        /// <param name="plat"></param>
        private void LlenarTablaExtras(Plato plat)
        {
            // Agrega las columnas a la tabla
            dataGridViewExtras.Rows.Clear();
            dataGridViewExtras.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridViewExtras.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewExtras.ColumnCount = 3; // Add one more column for the checkbox
            dataGridViewExtras.Columns[0].Name = "Identificación";
            dataGridViewExtras.Columns[1].Name = "Descripción";
            dataGridViewExtras.Columns[2].Name = "Precio";

            foreach (Extra ex in extras) // Agrega por cada extra la información a la tabla
            {
                if (ex != null && ex.Categoria.ID == plat.Categoria.ID)
                {
                    string[] fila = new string[] { ex.ID.ToString(), ex.Descripcion, ex.Precio.ToString(), "" };
                    dataGridViewExtras.Rows.Add(fila);
                }
            }

            // Agrega un checkbox para seleccionar los platos
            DataGridViewCheckBoxColumn checkBoxColumna = new DataGridViewCheckBoxColumn();
            checkBoxColumna.Name = "Seleccionar";
            dataGridViewExtras.Columns.Add(checkBoxColumna);

            if (exPedido != null)
            {
                foreach (DataGridViewRow fila in dataGridViewExtras.Rows) // Chequear las casillas en base a exPedido
                {
                    int extraId = int.Parse(fila.Cells["Identificación"].Value.ToString());

                    //se define si el extra se encuentra en el array de extras relacionado con el plato
                    bool estaSeleccionado = exPedido.Any(ep => ep.Extra.Any(ex => ex.ID == extraId) && ep.Plato.ID == plat.ID);

                    // coloca el valor del checkbox
                    DataGridViewCheckBoxCell checkBoxCell = fila.Cells["Seleccionar"] as DataGridViewCheckBoxCell;
                    checkBoxCell.Value = estaSeleccionado;
                }
            }

            foreach (DataGridViewColumn columna in dataGridViewExtras.Columns) // Hace que todo sea ReadOnly, excepto el checkbox
            {
                if (columna.Name != "Seleccionar")
                {
                    columna.ReadOnly = true;
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        /// <summary>
        /// Permite evitar errores de deteccion del estado de la columna seleccionar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewExtras_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewExtras.IsCurrentCellDirty)
            {
                dataGridViewExtras.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Detecta la seleccion y deseleccion de un extra en la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewExtras_CellContentClick(object sender, DataGridViewCellEventArgs e)//el ususario selecciono un extra
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBoxCasilla = dataGridViewExtras.Rows[e.RowIndex].Cells["Seleccionar"] as DataGridViewCheckBoxCell;
                try
                {
                    if (checkBoxCasilla.Value != null && (bool)checkBoxCasilla.Value || !(bool)checkBoxCasilla.Value)
                    {
                        Extra[] extrasseleccionadas = extrasseleccionados_tabla();

                        // obtiene el registro de extras para el plato seleccionado
                        ExtraPedido exPlato = exPedido.FirstOrDefault(ep => ep.Plato.ID == platoExtraseleccionado.ID);

                        if (exPlato != null)
                        {
                            // Actualiza el array de extras
                            exPlato.Extra = extrasseleccionadas;
                        }
                        else
                        {
                            // Si no hay registro, lo crea
                            ExtraPedido nuevoExtraPedido = new ExtraPedido(IdPedido, platoExtraseleccionado, extrasseleccionadas);
                            exPedido.Add(nuevoExtraPedido);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Ocurrio un erro al detectar seleccion de extras");
                }
            }
        }

        /// <summary>
        /// Obtiene una Array de los extras seleccionados
        /// </summary>
        /// <returns></returns>
        private Extra[] extrasseleccionados_tabla()
        {
            List<Extra> ExtrasSeleccionadas = new List<Extra>(); // lista para guardas las extras seleccionadas

            foreach (DataGridViewRow fila in dataGridViewExtras.Rows) // revisa cada fila de la tabla
            {
                DataGridViewCheckBoxCell checkBoxCasilla = fila.Cells["Seleccionar"] as DataGridViewCheckBoxCell; // copia la columna de seleccion

                if (checkBoxCasilla.Value != null && (bool)checkBoxCasilla.Value) // revisa el valor de selccion
                {
                    int id = Convert.ToInt32(fila.Cells["Identificación"].Value); // si esta seleccionado, toma el id del plato

                    foreach (Extra ext in extras) // busca y guarda el plato en la lista
                    {
                        if (ext != null && ext.ID == id)
                        {
                            ExtrasSeleccionadas.Add(ext);
                            break;
                        }
                    }
                }
            }
            return ExtrasSeleccionadas.ToArray(); // devuelve la lista de platos seleccionados
        }

        /// <summary>
        /// Realiza una cuenta de los platos seleccionados
        /// </summary>
        /// <returns></returns>
        private int PlatosSeleccionadosCuenta() //cuenta cuantos platos fueron seleccionados por el usuario
        {
            int seleccionados = 0;

            foreach (DataGridViewRow fila in dataGridViewPlatos.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = fila.Cells["Seleccionar"] as DataGridViewCheckBoxCell;

                if (checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                {
                    seleccionados++;
                }
            }

            return seleccionados;
        }

        /// <summary>
        /// Crea objeto Pedido y los envia para registrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReg_Click(object sender, EventArgs e)
        {
            int CuentaPlatosSeleccionados = PlatosSeleccionadosCuenta();

            //verifica que se haya seleccionado un plato
            if (CuentaPlatosSeleccionados == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un plato.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //si selecciono almenos 1 plato, pregunta si está seguro de su seleccion, dando opcion para cambiar algun plato
            else if (CuentaPlatosSeleccionados  > 0)
            {
                DialogResult resultado = MessageBox.Show($"Usted ha seleccionado {CuentaPlatosSeleccionados} platos. ¿Desea confirmar su selección? Seleccione No para cambiar su selección de platos.", "Confirmar Selección?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                    return;
            }
            //crea el pedido con los elementos seleccionados
            PedidoConstruido = new Pedido(IdPedido, Program.usuario, PlatosSeleccionados.ToArray(), DateTime.Now, exPedido.ToArray());
            //envia el pedido a Program para uso global.
            Program.pedido = PedidoConstruido;
            Program.PedidoPendiente = true;
            MessageBox.Show("Precione (Procesar Pedido) en el menú para observar y confirmar su pedido", "Selección Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information); //muestra mesaje de confirmacion

            //limpia el formulario
            comboBoxRest.Items.Clear();
            dataGridViewPlatos.Rows.Clear();
            comboBoxPlatos.Items.Clear();
            dataGridViewExtras.Rows.Clear();
            buttonAso.Enabled = false;
            comboBoxPlatos.Enabled = false;
            comboBoxRest.Enabled = false;
        }
    }
}

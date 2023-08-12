using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Consulta
{
    public partial class ConPlatoRest : Form
    {
        private Plato[] platos;
        private PlatoRestaurante[] platosRestaurante;
        private Restaurante[] restaurantes;
        public ConPlatoRest()
        {
            InitializeComponent();
            CargarArrays();
            if (restaurantes != null)
            { llenarcomboboxRest(); }
        }

        /// <summary>
        /// Obtiene los Restaurantes, Platos y Registros PlatoRestaurante de la DB
        /// </summary>
        private void CargarArrays()
        {
            restaurantes = Program.datosSQL.ObtenerRestaurantes();
            platos = Program.datosSQL.ObtenerPlatos();
            if (restaurantes == null || platos == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de restaurante en Form ConPlatoRest");
                Program.bitacora.Nuevolog = true;
            }
            else
            {
                platosRestaurante = Program.datosSQL.ObtenerPlatoRest(restaurantes, platos);
                if (platosRestaurante == null)
                {
                    MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de restaurante en Form ConPlatoRest");
                    Program.bitacora.Nuevolog = true;
                }
            }
        }

        /// <summary>
        /// Llena el combobox de seleccion para Restaurante
        /// </summary>
        private void llenarcomboboxRest()
        {
            foreach (Restaurante rest in restaurantes)
            {
                if (rest != null && rest.Estado == true) //solo si el restaurante está activo
                {
                    string reststring = rest.ID.ToString() + " - " + rest.Nombre + " - " + rest.Direccion;
                    comboBoxRest.Items.Add(reststring);
                }
            }
        }

        /// <summary>
        /// Obtiene el restaurante seleccionado en el combobox
        /// </summary>
        /// <returns>
        /// Objeto Restaurante seleccionado
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
        /// Llena la tabla con la info del Restaurante seleccionado
        /// </summary>
        /// <param name="r"></param>
        private void llenartablaRest(Restaurante r)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.ColumnCount = 3;
            dataGridView2.Columns[0].Name = "Id de Restaurante";
            dataGridView2.Columns[1].Name = "Nombre";
            dataGridView2.Columns[2].Name = "Dirección";

            foreach (Restaurante rest in restaurantes)
            {
                if (rest != null && rest.ID == r.ID)
                {
                    string[] fila = new string[] { rest.ID.ToString(), rest.Nombre, rest.Direccion };
                    dataGridView2.Rows.Add(fila);
                }
            }
        }

        /// <summary>
        /// Llena la tabla con los Platos asociados al Restaurante seleccionado
        /// </summary>
        private void llenartablaaplatosasociados()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Id del plato";
            dataGridView1.Columns[1].Name = "Nombre del plato";
            dataGridView1.Columns[2].Name = "Precio";
            dataGridView1.Columns[3].Name = "Id de Categoría";

            Restaurante selectedRestaurante = restseleccionado();

            if (selectedRestaurante != null)
            {
                foreach (PlatoRestaurante registro in platosRestaurante)
                {
                    if (registro != null && registro.Restaurante.ID == selectedRestaurante.ID)
                    {
                        foreach (Plato plat in registro.Platos)
                        {
                            if (plat != null)
                            {
                                string[] fila = new string[] { plat.ID.ToString(), plat.Nombre, plat.Precio.ToString(), plat.Categoria.ID.ToString() };
                                dataGridView1.Rows.Add(fila);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Detecta si el usuario selecciona un restaurante y ejecuta el llenado de tablas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxRest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Restaurante rest = restseleccionado();
            if (rest != null)
            {
                llenartablaRest(rest);
                llenartablaaplatosasociados();
            }
            else
            {
                dataGridView2.Rows.Clear();
                dataGridView1.Rows.Clear();
            }
        }
    }
}

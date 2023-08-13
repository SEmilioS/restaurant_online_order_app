using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Configuration;

namespace RestOrderingApp.Formularios.Consulta
{
    public partial class ConRestaurante : Form
    {
        private Restaurante[] restaurantes;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public ConRestaurante()
        {
            InitializeComponent();
            SetLanguage();
            CargarArrays();
            if (restaurantes != null)
            { llenartabla(); }
        }
        private void SetLanguage()
        {
            string selectedLanguage = ConfigurationManager.AppSettings["Language"]; // Get language setting from configuration

            if (selectedLanguage == "es")
            {
                manager = new ResourceManager($"RestOrderingApp.esCR",
                                                        typeof(Program).Assembly);
            }
            else if (selectedLanguage == "eng")
            {
                manager = new ResourceManager($"RestOrderingApp.engUS",
                                            typeof(Program).Assembly);
            }
            label1.Text = manager.GetString("conRest_titulo");
            label2.Text = manager.GetString("conRest_info");
        }

        /// <summary>
        /// Obtiene los Restaurantes de la DB
        /// </summary>
        private void CargarArrays()
        {
            restaurantes = Program.datosSQL.ObtenerRestaurantes();
            if (restaurantes == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de restaurante en Form ConRestaurante");
                Program.bitacora.Nuevolog = true;
            }

        }

        /// <summary>
        /// Llena la tabla con la info de cada Restaurante
        /// </summary>
        private void llenartabla()
        {
            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.ColumnCount = 5;
            dataGridView2.Columns[0].Name = manager.GetString("Columna_RestID");
            dataGridView2.Columns[1].Name = manager.GetString("Columna_RestNombre");
            dataGridView2.Columns[2].Name = manager.GetString("Columna_RestDireccion");
            dataGridView2.Columns[3].Name = manager.GetString("Columna_Estado");
            dataGridView2.Columns[4].Name = manager.GetString("Columna_Telefono");

            foreach (Restaurante rest in restaurantes) //por cada restaurante agrega una fila de info
            {
                if (rest != null)
                {
                    string[] fila = new string[] { rest.ID.ToString(), rest.Nombre, rest.Direccion, rest.Estado ? manager.GetString("Estado1") : manager.GetString("Estado2"), rest.Telefono };
                    dataGridView2.Rows.Add(fila);
                }
            }
        }
    }
}

using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Configuration;

namespace RestOrderingApp.Formularios.Consulta
{
    public partial class ConCatPlato : Form
    {
        private CategoriaPlato[] categoriasplato;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public ConCatPlato()
        {
            InitializeComponent();
            SetLanguage();
            CargarArrays();
            if (categoriasplato != null)
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
            label1.Text = manager.GetString("conCatPlato_titulo");
            label2.Text = manager.GetString("conCatPlato_info");
        }

        /// <summary>
        /// Obtiene las Categorias de la DB
        /// </summary>
        private void CargarArrays()
        {
            categoriasplato = Program.datosSQL.ObtenerCategorias();
            if (categoriasplato == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de restaurante en Form ConCatPlato");
                Program.bitacora.Nuevolog = true;
            }

        }

        /// <summary>
        /// Llena la tabla con la info de cada categoria
        /// </summary>
        private void llenartabla()
        {
            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.ColumnCount = 3;
            dataGridView2.Columns[0].Name = manager.GetString("Columna_Categoria");
            dataGridView2.Columns[1].Name = manager.GetString("Columna_Descripcion");
            dataGridView2.Columns[2].Name = manager.GetString("Columna_Estado");

            foreach (CategoriaPlato rest in categoriasplato) //por cada categoria crea una fila
            {
                if (rest != null)
                {
                    string[] fila = new string[] { rest.ID.ToString(), rest.Descripcion, rest.Estado ? manager.GetString("Estado1") : manager.GetString("Estado2") };
                    dataGridView2.Rows.Add(fila);
                }
            }
        }
    }
}

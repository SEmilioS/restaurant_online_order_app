using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Configuration;

namespace RestOrderingApp.Formularios.Consulta
{
    public partial class ConExtras : Form
    {
        private Extra[] extras;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public ConExtras()
        {
            InitializeComponent();
            SetLanguage();
            CargarArrays();
            if (extras != null)
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
            label1.Text = manager.GetString("conExtras_titulo");
            label2.Text = manager.GetString("conExtras_info");
        }

        /// <summary>
        /// Obtiene las Extras de la DB
        /// </summary>
        private void CargarArrays()
        {
            extras = Program.datosSQL.ObtenerExtras();
            if (extras == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de restaurante en Form ConExtras");
                Program.bitacora.Nuevolog = true;
            }

        }

        /// <summary>
        /// Llena la tabla con la info de cada Extra
        /// </summary>
        private void llenartabla()
        {
            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.ColumnCount = 6;
            dataGridView2.Columns[0].Name = manager.GetString("Columna_ExtraID");
            dataGridView2.Columns[1].Name = manager.GetString("Columna_Descripcion");
            dataGridView2.Columns[2].Name = manager.GetString("Columna_Precio");
            dataGridView2.Columns[3].Name = manager.GetString("Columna_Categoria");
            dataGridView2.Columns[4].Name = manager.GetString("Columna_Estado");

            foreach (Extra ex in extras) //agrega por cada extra la informacion a la tabla
            {
                if (ex != null)
                {
                    string[] fila = new string[] { ex.ID.ToString(), ex.Descripcion, ex.Precio.ToString(), ex.Categoria.ID.ToString(), ex.Estado ? manager.GetString("Estado1") : manager.GetString("Estado2") };
                    dataGridView2.Rows.Add(fila);
                }
            }
        }
    }
}

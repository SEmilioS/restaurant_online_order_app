using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Configuration;

namespace RestOrderingApp.Formularios.Consulta
{
    public partial class ConCliente : Form
    {
        private Cliente[] clientes;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public ConCliente()
        {
            InitializeComponent();
            SetLanguage();
            CargarArrays();
            if (clientes != null)
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
            label1.Text = manager.GetString("conCliente_titulo");
            label2.Text = manager.GetString("conCliente_info");
        }

        /// <summary>
        /// Obtiene los Clientes de la DB
        /// </summary>
        private void CargarArrays()
        {
            clientes = Program.datosSQL.ObtenerClientes();
            if (clientes == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de restaurante en Form ConCliente");
                Program.bitacora.Nuevolog = true;
            }

        }

        /// <summary>
        /// LLena la tabla con la info de cada Cliente
        /// </summary>
        private void llenartabla()
        {
            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.ColumnCount = 6;
            dataGridView2.Columns[0].Name = manager.GetString("regCliente_id");
            dataGridView2.Columns[1].Name = manager.GetString("regCliente_nombre");
            dataGridView2.Columns[2].Name = manager.GetString("regCliente_apellido1");
            dataGridView2.Columns[3].Name = manager.GetString("regCliente_apellido2");
            dataGridView2.Columns[4].Name = manager.GetString("regCliente_nacimiento");
            dataGridView2.Columns[5].Name = manager.GetString("regCliente_genero");

            foreach (Cliente rest in clientes) //Crea una fila por cada cliente
            {
                if (rest != null)
                {
                    string[] fila = new string[] { rest.Identificacion, rest.Nombre, rest.Primer_Apellido, rest.Segundo_Apellido, rest.Fecha_nacimiento.ToString("dd/MM/yyyy"), rest.Genero.ToString() };
                    dataGridView2.Rows.Add(fila);
                }
            }
        }
    }
}

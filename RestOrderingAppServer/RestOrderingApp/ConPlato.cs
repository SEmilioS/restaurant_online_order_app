using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;

namespace RestOrderingApp.Formularios.Consulta
{
    public partial class ConPlato : Form
    {
        private Plato[] platos;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public ConPlato()
        {
            InitializeComponent();
            SetLanguage();
            CargarArrays();
            if (platos != null)
            { llenartabla(); }
        }

        private void SetLanguage()
        {
            SelectorLenguaje sl = new SelectorLenguaje();
            manager = sl.CargarLenguaje();
            label1.Text = manager.GetString("conPlato_titulo");
            label2.Text = manager.GetString("conPlato_info");
        }

        /// <summary>
        /// Obtiene los Platos de la DB
        /// </summary>
        private void CargarArrays()
        {
            platos = Program.datosSQL.ObtenerPlatos();
            if (platos == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de restaurante en Form ConPlato");
                Program.bitacora.Nuevolog = true;
            }

        }

        /// <summary>
        /// Llena la tabla con la info de cada Plato
        /// </summary>
        private void llenartabla()
        {
            dataGridView2.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].Name = manager.GetString("Columna_IDPlato");
            dataGridView2.Columns[1].Name = manager.GetString("Columna_NombrePlato");
            dataGridView2.Columns[2].Name = manager.GetString("Columna_Precio");
            dataGridView2.Columns[3].Name = manager.GetString("Columna_Categoria");

            foreach (Plato rest in platos) //crea una fila por cada plato registrado
            {
                if (rest != null)
                {
                    string[] fila = new string[] { rest.ID.ToString(), rest.Nombre, rest.Precio.ToString(), rest.Categoria.ID.ToString() };
                    dataGridView2.Rows.Add(fila);
                }
            }
        }
    }
}

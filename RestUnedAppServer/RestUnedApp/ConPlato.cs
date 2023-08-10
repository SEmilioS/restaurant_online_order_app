using RestUnedClases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RestUnedApp.Formularios.Consulta
{
    public partial class ConPlato : Form
    {
        private Plato[] platos;
        public ConPlato()
        {
            InitializeComponent();
            CargarArrays();
            if (platos != null)
            { llenartabla(); }
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
            dataGridView2.Columns[0].Name = "Id del plato";
            dataGridView2.Columns[1].Name = "Nombre del plato";
            dataGridView2.Columns[2].Name = "Precio";
            dataGridView2.Columns[3].Name = "Id de Categoría";

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

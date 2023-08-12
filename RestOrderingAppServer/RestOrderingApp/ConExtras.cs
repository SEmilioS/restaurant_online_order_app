using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Consulta
{
    public partial class ConExtras : Form
    {
        private Extra[] extras;
        public ConExtras()
        {
            InitializeComponent();
            CargarArrays();
            if (extras != null)
            { llenartabla(); }
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
            dataGridView2.Columns[0].Name = "Identificación";
            dataGridView2.Columns[1].Name = "Descripción";
            dataGridView2.Columns[2].Name = "Precio";
            dataGridView2.Columns[3].Name = "Id de Categoría";
            dataGridView2.Columns[4].Name = "Estado";

            foreach (Extra ex in extras) //agrega por cada extra la informacion a la tabla
            {
                if (ex != null)
                {
                    string[] fila = new string[] { ex.ID.ToString(), ex.Descripcion, ex.Precio.ToString(), ex.Categoria.ID.ToString(), ex.Estado ? "Activo" : "Inactivo" };
                    dataGridView2.Rows.Add(fila);
                }
            }
        }
    }
}

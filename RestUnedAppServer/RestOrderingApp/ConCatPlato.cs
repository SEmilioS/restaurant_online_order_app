using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Consulta
{
    public partial class ConCatPlato : Form
    {
        private CategoriaPlato[] categoriasplato;
        public ConCatPlato()
        {
            InitializeComponent();
            CargarArrays();
            if (categoriasplato != null)
            { llenartabla(); }
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
            dataGridView2.Columns[0].Name = "Id de categoria";
            dataGridView2.Columns[1].Name = "Descripción";
            dataGridView2.Columns[2].Name = "Estado";

            foreach (CategoriaPlato rest in categoriasplato) //por cada categoria crea una fila
            {
                if (rest != null)
                {
                    string[] fila = new string[] { rest.ID.ToString(), rest.Descripcion, rest.Estado ? "Activo" : "Inactivo" };
                    dataGridView2.Rows.Add(fila);
                }
            }
        }
    }
}

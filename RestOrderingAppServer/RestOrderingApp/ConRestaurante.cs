using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Consulta
{
    public partial class ConRestaurante : Form
    {
        private Restaurante[] restaurantes;
        public ConRestaurante()
        {
            InitializeComponent();
            CargarArrays();
            if (restaurantes != null)
            { llenartabla(); }
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
            dataGridView2.Columns[0].Name = "Id de restaurante";
            dataGridView2.Columns[1].Name = "Nombre del restaurante";
            dataGridView2.Columns[2].Name = "Dirección";
            dataGridView2.Columns[3].Name = "Estado";
            dataGridView2.Columns[4].Name = "Teléfono";

            foreach (Restaurante rest in restaurantes) //por cada restaurante agrega una fila de info
            {
                if (rest != null)
                {
                    string[] fila = new string[] { rest.ID.ToString(), rest.Nombre, rest.Direccion, rest.Estado ? "Activo" : "Inactivo", rest.Telefono };
                    dataGridView2.Rows.Add(fila);
                }
            }
        }
    }
}

using RestUnedClases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RestUnedApp.Formularios.Consulta
{
    public partial class ConCliente : Form
    {
        private Cliente[] clientes;
        public ConCliente()
        {
            InitializeComponent();
            CargarArrays();
            if (clientes != null)
            { llenartabla(); }
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
            dataGridView2.Columns[0].Name = "Identificación";
            dataGridView2.Columns[1].Name = "Nombre";
            dataGridView2.Columns[2].Name = "Primer Apellido";
            dataGridView2.Columns[3].Name = "Segundo Apellido";
            dataGridView2.Columns[4].Name = "Fecha de nacimiento";
            dataGridView2.Columns[5].Name = "Genero";

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

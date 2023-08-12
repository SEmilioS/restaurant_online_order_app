using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;
using RestOrderingAppClient.Server.Client;

namespace RestOrderingAppClient.Formularios.Registrar
{
    public partial class ProcesarPedido : Form
    {
        //variables de datos
        private Plato[] platos;
        private ExtraPedido[] extras;

        //Variables finales (producto Pedido)
        private Pedido PedidoFinal;

        public ProcesarPedido()
        {
            InitializeComponent();
            Client client = new Client();
            client.CheckSesion();
            client.CloseConnection();
            if (Program.PedidoPendiente == false)
            {
                buttonConfirmar.Enabled = false;
                comboBoxPlatos.Enabled = false;
                panelErrorReg.Visible = true;
            }
            else
            {
                panelErrorReg.Visible = false;
                platos = Program.pedido.Plato;
                extras = Program.pedido.extraPedidos;
                llenartablaPlatos();
                llenarcomboboxPlatos();
                llenarTablaCostos();
            }
        }

        /// <summary>
        /// Llena la tabla con los platos seleccionados del pedido
        /// </summary>
        private void llenartablaPlatos()
        {
            dataGridViewPlatos.Rows.Clear();
            dataGridViewPlatos.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridViewPlatos.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewPlatos.ColumnCount = 3;
            dataGridViewPlatos.Columns[0].Name = "Id del plato";
            dataGridViewPlatos.Columns[1].Name = "Nombre del plato";
            dataGridViewPlatos.Columns[2].Name = "Precio";

            foreach (Plato plat in platos)
            {
                if (plat != null)//agrega cada plato que no esta asociado con el restaurante
                {
                    string[] fila = new string[] { plat.ID.ToString(), plat.Nombre, plat.Precio.ToString() };
                    dataGridViewPlatos.Rows.Add(fila);
                }
            }

            foreach (DataGridViewColumn columna in dataGridViewPlatos.Columns) //hace que todo sea Read only menos el checkbox
            {
                columna.ReadOnly = true;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        /// <summary>
        /// Por cada plato agrega un item al combobox de extras
        /// </summary>
        private void llenarcomboboxPlatos()
        {
            comboBoxPlatos.Items.Clear();
            foreach (Plato plat in platos)
            {
                if (plat != null)
                {
                    string platstring = plat.ID.ToString() + " - " + plat.Nombre;
                    comboBoxPlatos.Items.Add(platstring);
                }
            }
        }

        /// <summary>
        /// Detecta la seleccion de un plato en el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPlatos_seleccionado(object sender, EventArgs e)
        {
            Plato PlatoSeleccionado = PlatoSeleccionado_comboBox();
            LlenarTablaExtras(PlatoSeleccionado);
        }

        /// <summary>
        /// Obtiene objeto Plato segun la selecion del combobox
        /// </summary>
        /// <returns></returns>
        private Plato PlatoSeleccionado_comboBox()
        {
            if (comboBoxPlatos.SelectedItem == null)
            {
                return null;
            }

            string itemseleccionado = comboBoxPlatos.SelectedItem.ToString(); // convierte a string el item seleccionado
            int IndexSeparador = itemseleccionado.IndexOf(" - "); // encuentra el index de la primera ocurrencia de  " - "

            if (IndexSeparador != -1) // asegura que haya encontrado el patron " - "
            {
                string idString = itemseleccionado.Substring(0, IndexSeparador).Trim(); // extrae la id de la string
                if (int.TryParse(idString, out int id)) // convierte a int la id
                {
                    foreach (Plato plat in platos) // busca el plato
                    {
                        if (plat != null && plat.ID == id)
                        {
                            return plat;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Llena la tabla de extras segun el plato seleccionado
        /// </summary>
        /// <param name="plat"></param>
        private void LlenarTablaExtras(Plato plat)
        {
            // Agrega las columnas a la tabla
            dataGridViewExtras.Rows.Clear();
            dataGridViewExtras.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridViewExtras.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewExtras.ColumnCount = 3; // Add one more column for the checkbox
            dataGridViewExtras.Columns[0].Name = "Identificación";
            dataGridViewExtras.Columns[1].Name = "Descripción";
            dataGridViewExtras.Columns[2].Name = "Precio";

            foreach (ExtraPedido exp in extras)
            {
                if (exp != null && exp.Plato.ID == plat.ID)
                {
                    foreach (Extra ex in exp.Extra)
                    {
                        string[] fila = new string[] { ex.ID.ToString(), ex.Descripcion, ex.Precio.ToString(), "" };
                        dataGridViewExtras.Rows.Add(fila);
                    }
                }
            }

            foreach (DataGridViewColumn columna in dataGridViewExtras.Columns) // Hace que todo sea ReadOnly, excepto el checkbox
            {
                columna.ReadOnly = true;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        /// <summary>
        /// suma el valor de los platos del pedido
        /// </summary>
        /// <returns></returns>
        private int subtotalPlatos()
        {
            int subtotal = 0;
            foreach (Plato pl in platos)
            {
                if (pl != null)
                {
                    subtotal += pl.Precio;
                }
            }
            return subtotal;
        }

        /// <summary>
        /// Suma el valor de los extras del pedido
        /// </summary>
        /// <returns></returns>
        private int subTotalExtras()
        {
            int subtotal = 0;
            foreach (ExtraPedido exp in extras)
            {
                if (exp != null)
                {
                    foreach (Extra ex in exp.Extra)
                    {
                        if (ex != null)
                        {
                            subtotal += ex.Precio;
                        }

                    }

                }
            }
            return subtotal;
        }

        /// <summary>
        /// Llena la tabla de costos del pedido
        /// </summary>
        private void llenarTablaCostos()
        {
            // Agrega las columnas a la tabla
            dataGridViewCostos.Rows.Clear();
            dataGridViewCostos.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridViewCostos.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewCostos.ColumnCount = 3; // Add one more column for the checkbox

            int stPlatos = subtotalPlatos();
            int stExtras = subTotalExtras();
            string[] filaSubtotalPlato = new string[] { "SubTotal Platos:", "       ", stPlatos.ToString() };
            dataGridViewCostos.Rows.Add(filaSubtotalPlato);
            string[] filaSubtotalExtra = new string[] { "SubTotal Extras:", "       ", stExtras.ToString() };
            dataGridViewCostos.Rows.Add(filaSubtotalExtra);
            string[] filaTotal = new string[] { "Total:", "     ", (stPlatos + stExtras).ToString() };
            dataGridViewCostos.Rows.Add(filaTotal);
        }

        /// <summary>
        /// Crea objeto Pedido final y lo envia al servidor para su procesamiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReg_Click(object sender, EventArgs e)
        {
            buttonConfirmar.Enabled = false;
            PedidoFinal = Program.pedido;
            bool estado;
            Client client = new Client();
            estado = client.ProcesarPedido(PedidoFinal);// se recibe confimacion del servidor
            client.CloseConnection();
            if (estado)
            {
                MessageBox.Show("Su pedido ha sido procesado existosamente", "Pedido Procesado", MessageBoxButtons.OK, MessageBoxIcon.Information); //muestra mesaje de confirmacion
                dataGridViewPlatos.Rows.Clear();
                dataGridViewExtras.Rows.Clear();
                dataGridViewCostos.Rows.Clear();
                comboBoxPlatos.Items.Clear();
                Program.pedido = null;
                Program.PedidoPendiente = false;
                return;
            }
            else
            {
                MessageBox.Show("Su pedido no se ha logrado procesar. Por favor, intente denuevo.", "Pedido No Procesado", MessageBoxButtons.OK, MessageBoxIcon.Error); //muestra mesaje de confirmacion
                buttonConfirmar.Enabled = true;
                return;
            }
        }
    }
}

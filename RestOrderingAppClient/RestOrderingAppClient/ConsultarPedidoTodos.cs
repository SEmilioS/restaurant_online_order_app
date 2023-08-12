using RestOrderingClases;
using System;
using System.Drawing;
using System.Windows.Forms;
using RestOrderingAppClient.Server.Client;

namespace RestOrderingAppClient.Formularios.Cosultar
{
    public partial class ConsultarPedidoTodos : Form
    {
        //variables de datos
        private Pedido[] pedidos;

        public ConsultarPedidoTodos()
        {
            InitializeComponent();
            panelErrorReg.Visible = false;
            pedidos = SolicitarInformacion();//solicita todos los pedidos registrados del cliente
            if (pedidos == null) //se recibe error de DB
            {
                panelErrorReg.Visible = true;
                labelerrorDB.Visible = true;
                labelFaltaInfo.Visible = false;
            }
            else if (pedidos.Length == 0) //no hay pedidos
            {
                panelErrorReg.Visible = true;
                labelerrorDB.Visible = false;
                labelFaltaInfo.Visible = true;
            }
            else //si hay pedidos :)
            {
                llenartablaPedidos();
                llenarComboBoxPedidos();
            }
        }

        /// <summary>
        /// Solicita Pedidos al servidor
        /// </summary>
        /// <returns></returns>
        private Pedido[] SolicitarInformacion()
        {
            Client client = new Client();
            Pedido[] pedidos;
            string idCliente = Program.usuario.Identificacion;
            pedidos = client.SolicitarPedidos(idCliente);
            client.CloseConnection();
            return pedidos;
        }

        /// <summary>
        /// Llena el combobox de pedidos
        /// </summary>
        private void llenarComboBoxPedidos()
        {
            foreach (Pedido ped in pedidos)
            {
                if (ped != null)
                {
                    string reststring = ped.IdPedido.ToString() + " - " + ped.Cliente.Nombre + " - " + ped.Cliente.Primer_Apellido + " - " + ped.Cliente.Segundo_Apellido + " - " + "Fecha de pedido: " + ped.FechaPedido.ToString("dd/MM/yyyy") + " - ";
                    comboBoxPedidos.Items.Add(reststring);
                }
            }
        }

        /// <summary>
        /// Obtiene objeto Pedido con el pedido selecionado
        /// </summary>
        /// <returns></returns>
        private Pedido PedidoSeleccionado() //obtiene y devuelve el restaurante seleccionado
        {
            if (comboBoxPedidos.SelectedItem == null)
            {
                return null;
            }

            string itemseleccionado = comboBoxPedidos.SelectedItem.ToString(); // convierte a string el item seleccionado
            int IndexSeparador = itemseleccionado.IndexOf(" - "); // encuentra el index de la primera ocurrencia de  " - "

            if (IndexSeparador != -1) // asegura que haya encontrado el patron " - "
            {
                string idString = itemseleccionado.Substring(0, IndexSeparador).Trim(); // extrae la id de la string
                if (int.TryParse(idString, out int id)) // convierte a int la id
                {
                    foreach (Pedido ped in pedidos) // busca el restuarante
                    {
                        if (ped != null && ped.IdPedido == id)
                        {
                            return ped;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Detecta una seleccion en el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarTablaCostos();
        }

        /// <summary>
        /// Llena la tabla de pedidos
        /// </summary>
        private void llenartablaPedidos() //llena la tabla de platos disponibles para registrar
        {
            dataGridViewPedidos.Rows.Clear();
            dataGridViewPedidos.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridViewPedidos.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewPedidos.ColumnCount = 5;
            dataGridViewPedidos.Columns[0].Name = "IdPedido";
            dataGridViewPedidos.Columns[1].Name = "Nombre Cliente";
            dataGridViewPedidos.Columns[2].Name = "Primer Apellido";
            dataGridViewPedidos.Columns[3].Name = "Segundo Apellido";
            dataGridViewPedidos.Columns[4].Name = "Fecha del Pedido";

            foreach (Pedido ped in pedidos)
            {
                if (ped != null)//agrega cada plato que no esta asociado con el restaurante
                {
                    string[] fila = new string[] { ped.IdPedido.ToString(), ped.Cliente.Nombre, ped.Cliente.Primer_Apellido, ped.Cliente.Segundo_Apellido, ped.FechaPedido.ToString("dd/MM/yyyy") };
                    dataGridViewPedidos.Rows.Add(fila);
                }
            }
            foreach (DataGridViewColumn columna in dataGridViewPedidos.Columns) //hace que todo sea Read only menos el checkbox
            {
                columna.ReadOnly = true;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        /// <summary>
        /// Realiza suma de valor de los platos
        /// </summary>
        /// <param name="ped"></param>
        /// <returns></returns>
        private int subtotalPlatos(Pedido ped)
        {
            Plato[] platos = ped.Plato;
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
        /// Realiza suma de valor de los extras y la cantidad de extras
        /// </summary>
        /// <param name="ped"></param>
        /// <returns></returns>
        private int[] subTotalExtras(Pedido ped)
        {
            ExtraPedido[] extras = ped.extraPedidos;
            int[] subtotal = new int[2];
            foreach (ExtraPedido exp in extras)
            {
                if (exp != null)
                {
                    foreach (Extra ex in exp.Extra)
                    {
                        if (ex != null)
                        {
                            subtotal[0] += ex.Precio;
                            subtotal[1]++;
                        }

                    }

                }
            }
            return subtotal;
        }

        /// <summary>
        /// Llena la tabla de costos segun el pedido seleccionado
        /// </summary>
        private void llenarTablaCostos()
        {
            // Agrega las columnas a la tabla
            dataGridViewCostos.Rows.Clear();
            dataGridViewCostos.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridViewCostos.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewCostos.ColumnCount = 4; // Add one more column for the checkbox

            Pedido ped = PedidoSeleccionado();
            int stPlatos = subtotalPlatos(ped);
            int[] stExtras = subTotalExtras(ped);
            string[] filaSubtotalPlato = new string[] { "SubTotal Platos:", "   " + ped.Plato.Length + "    ", "    ", stPlatos.ToString() };
            dataGridViewCostos.Rows.Add(filaSubtotalPlato);
            string[] filaSubtotalExtra = new string[] { "SubTotal Extras:", "   " + stExtras[1] + "    ", "    ", stExtras[0].ToString() };
            dataGridViewCostos.Rows.Add(filaSubtotalExtra);
            string[] filaTotal = new string[] { "Total:", "       ", "       ", (stPlatos + stExtras[0]).ToString() };
            dataGridViewCostos.Rows.Add(filaTotal);
        }

    }
}

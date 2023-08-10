using RestUnedClases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RestUnedAppCliente.Server.Client;

namespace RestUnedAppCliente.Formularios.Cosultar
{
    public partial class ConsultarPedidoUnico : Form
    {
    //variables de datos
    private Pedido[] pedidos;

    public ConsultarPedidoUnico()
    {
        InitializeComponent();
        panelErrorReg.Visible = false;
        pedidos = SolicitarInformacion();//solicita los Pedidos relacionados al cliente
        if (pedidos == null)// error de base de datos
        {
            panelErrorReg.Visible = true;
            labelerrorDB.Visible = true;
            labelFaltaInfo.Visible = false;
        }
        else if (pedidos.Length == 0) // no hay pedidos
        {
            panelErrorReg.Visible = true;
            labelerrorDB.Visible = false;
            labelFaltaInfo.Visible = true;
        }
        else // si hay pedidos :)
        {
            llenarComboBoxPedidos();
        }
    }

    /// <summary>
    /// Solicita al servidor Array de Pedidos
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
    /// Llena le combobox de Pedidos
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
    /// Obtiene objeto Pedido con el Pedido selecionado
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
    /// Detecta la seleccion de un pedido en el combobox, llena las tablas
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void comboBoxPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Pedido pedidoSeleccionado = PedidoSeleccionado();
        llenartablaPlatos(pedidoSeleccionado);
        llenarcomboboxPlatos(pedidoSeleccionado);
        llenarTablaCostos();
    }

    /// <summary>
    /// Llena la tabla de platos del pedido
    /// </summary>
    /// <param name="ped"></param>
    private void llenartablaPlatos(Pedido ped)
    {
        dataGridViewPlatos.Rows.Clear();
        dataGridViewPlatos.DefaultCellStyle.Font = new Font("Arial", 12);
        dataGridViewPlatos.DefaultCellStyle.ForeColor = Color.Black;
        dataGridViewPlatos.ColumnCount = 3;
        dataGridViewPlatos.Columns[0].Name = "Id del plato";
        dataGridViewPlatos.Columns[1].Name = "Nombre del plato";
        dataGridViewPlatos.Columns[2].Name = "Precio";

        Plato[] platos = ped.Plato;

        foreach (Plato plat in platos)
        {
            if (plat != null)//agrega cada plato que no esta asociado con el pedido
            {
                string[] fila = new string[] { plat.ID.ToString(), plat.Nombre, plat.Precio.ToString() };
                dataGridViewPlatos.Rows.Add(fila);
            }
        }

        foreach (DataGridViewColumn columna in dataGridViewPlatos.Columns)
        {
            columna.ReadOnly = true;
            columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }

    /// <summary>
    /// Llena el combobox con los platos del pedido para extras
    /// </summary>
    /// <param name="ped"></param>
    private void llenarcomboboxPlatos(Pedido ped)
    {
        Plato[] platos = ped.Plato;
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
    /// Detecta la seleccion de un plato y muestra los extras segun este
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void comboBoxPlatos_seleccionado(object sender, EventArgs e)
    {
        Pedido ped = PedidoSeleccionado();
        Plato PlatoSeleccionado = PlatoSeleccionado_comboBox(ped);
        LlenarTablaExtras(PlatoSeleccionado, ped);
    }

    /// <summary>
    /// Obtiene objeto Plato para el plato seleccionado
    /// </summary>
    /// <param name="ped"></param>
    /// <returns></returns>
    private Plato PlatoSeleccionado_comboBox(Pedido ped)
    {
        Plato[] platos = ped.Plato;
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
    /// <param name="ped"></param>
    private void LlenarTablaExtras(Plato plat, Pedido ped)
    {
        ExtraPedido[] extras = ped.extraPedidos;
        // Agrega las columnas a la tabla
        dataGridViewExtras.Rows.Clear();
        dataGridViewExtras.DefaultCellStyle.Font = new Font("Arial", 12);
        dataGridViewExtras.DefaultCellStyle.ForeColor = Color.Black;
        dataGridViewExtras.ColumnCount = 3; 
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

        foreach (DataGridViewColumn columna in dataGridViewExtras.Columns) 
        {
            columna.ReadOnly = true;
            columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }

    /// <summary>
    /// Suma el valor de los platos
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
    /// Suma el valor de las extras
    /// </summary>
    /// <param name="ped"></param>
    /// <returns></returns>
    private int subTotalExtras(Pedido ped)
    {
        ExtraPedido[] extras = ped.extraPedidos;
        int subtotal = 0;
        foreach(ExtraPedido exp in extras) 
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
    /// Llena la tabla de costos segun el pedido
    /// </summary>
    private void llenarTablaCostos()
    {
        // Agrega las columnas a la tabla
        dataGridViewCostos.Rows.Clear();
        dataGridViewCostos.DefaultCellStyle.Font = new Font("Arial", 12);
        dataGridViewCostos.DefaultCellStyle.ForeColor = Color.Black;
        dataGridViewCostos.ColumnCount = 3;

        Pedido ped = PedidoSeleccionado();
        int stPlatos = subtotalPlatos(ped);
        int stExtras = subTotalExtras(ped);
        string[] filaSubtotalPlato = new string[] { "SubTotal Platos:", "       ", stPlatos.ToString() };
        dataGridViewCostos.Rows.Add(filaSubtotalPlato);
        string[] filaSubtotalExtra = new string[] { "SubTotal Extras:", "       ", stExtras.ToString() };
        dataGridViewCostos.Rows.Add(filaSubtotalExtra);
        string[] filaTotal = new string[] { "Total:", "     ", (stPlatos + stExtras).ToString() };
        dataGridViewCostos.Rows.Add(filaTotal);
    }

    }
}

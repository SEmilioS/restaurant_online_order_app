using RestUnedClases;
using System;
using System.Windows.Forms;

namespace RestUnedApp.Formularios.Registro
{
    public partial class RegCliente : Form
    {
        string[] clienteIDs;
        public RegCliente()
        {
            InitializeComponent();
            //esconde los paneles de error
            panelErrorID.Visible = false;
            labelidnounica.Visible = false;
            panelErrorReg.Visible = false;
            labelErrorDB.Visible = false;
            CargarIds();
        }

        /// <summary>
        /// Obtiene las ids de Clientes existentes
        /// </summary>
        private void CargarIds()
        {
            textBoxID.Enabled = false;
            buttonReg.Enabled = false;
            panelErrorID.Visible = true;
            labelcargando.Visible = true;
            clienteIDs = Program.datosSQL.ObtenerIdCliente();
            if (clienteIDs == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener Id de clientes");
                Program.bitacora.Nuevolog = true;
                labelcargando.Visible = false;
                labelErrorDB.Visible = true;
                return;
            }
            panelErrorID.Visible = false;
            labelcargando.Visible = false;
            textBoxID.Enabled = true;
            buttonReg.Enabled = true;
        }

        /// <summary>
        /// Verifica si la id digitada es int y valida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IdEsValida(object sender, EventArgs e) //verifica si la id es int y valida
        {
            panelErrorID.Visible = false;
            labelidnounica.Visible = false;
            string id = textBoxID.Text;
            bool noesvalida;
            noesvalida = ExisteID(id); //llama a funcion para verificar si es unico en DB
            if (noesvalida)
            {
                buttonReg.Enabled = false;
                panelErrorID.Visible = true;
                labelidnounica.Visible = true;
            }
            else { buttonReg.Enabled = true; }
        }

        /// <summary>
        /// Verifica si la id ya existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ExisteID(string id)
        {
            for (int i = 0; i < clienteIDs.Length; i++)
            {
                if (clienteIDs[i] == id)
                { return true; }
            }
            return false;
        }

        /// <summary>
        /// Verifica si se introdujo toda la info necesaria
        /// </summary>
        /// <returns></returns>
        private bool infocompleta()
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text)) //verifica que no esté vacio
            { return false; }
            if (string.IsNullOrEmpty(textBoxApellido1.Text))
            { return false; }
            if (string.IsNullOrEmpty(textBoxApellido2.Text))
            { return false; }
            if (comboBoxGenero.SelectedIndex == -1)//verifica que se haya selecciondo un valor
            { return false; }
            return true;
        }

        /// <summary>
        /// Crea un nuevo Clienete y lo envia para agregar a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReg_Click(object sender, EventArgs e)
        {
            if (infocompleta() == true) //verifica que los datos esten completos y correctos antes de continuar
            {
                //pone en formato correcto todos los datos
                string id = textBoxID.Text;
                string nombre = textBoxNombre.Text;
                string apellido1 = textBoxApellido1.Text;
                string apellido2 = textBoxApellido2.Text;
                string ItemSeleccionado = comboBoxGenero.SelectedItem.ToString();
                char genero;
                switch (ItemSeleccionado)
                {
                    case "M: Masculino":
                        genero = 'M';
                        break;
                    case "F: Femenino":
                        genero = 'F';
                        break;
                    case "O: Otro":
                        genero = 'O';
                        break;
                    default:
                        genero = 'o';
                        break;
                }
                DateTime nacimiento = dateTimePicker1.Value.Date;
                Cliente cliente = new Cliente(id, nombre, apellido1, apellido2, nacimiento, genero); //crea el objeto cliente
                Program.datosSQL.agregarcliente(cliente);//registra el cliente

                //limpia el form
                textBoxID.Text = "";
                textBoxNombre.Text = "";
                textBoxApellido1.Text = "";
                textBoxApellido2.Text = "";
                comboBoxGenero.SelectedIndex = -1;
                panelErrorReg.Visible = false;
                panelErrorID.Visible = false;
                CargarIds();
            }
            else
            { panelErrorReg.Visible = true; } //si no tiene los datos correctos o completos muestra error
        }
    }
}

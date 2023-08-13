using RestOrderingClases;
using System;
using System.Configuration;
using System.Resources;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Registro
{
    public partial class RegCliente : Form
    {
        string[] clienteIDs;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public RegCliente()
        {
            InitializeComponent();
            SetLanguage();
            //esconde los paneles de error
            panelErrorID.Visible = false;
            panelErrorReg.Visible = false;
            CargarIds();
        }

        private void SetLanguage()
        {
            string selectedLanguage = ConfigurationManager.AppSettings["Language"]; // Get language setting from configuration

            if (selectedLanguage == "es")
            {
                manager = new ResourceManager($"RestOrderingApp.esCR",
                                                        typeof(Program).Assembly);
            }
            else if (selectedLanguage == "eng")
            {
                manager = new ResourceManager($"RestOrderingApp.engUS",
                                            typeof(Program).Assembly);
            }
            label1.Text = manager.GetString("regCliente_titulo");
            label2.Text = manager.GetString("regCliente_instrucciones");
            label3.Text = manager.GetString("regCliente_id");
            label4.Text = manager.GetString("regCliente_nombre");
            label5.Text = manager.GetString("regCliente_apellido1");
            label6.Text = manager.GetString("regCliente_nacimiento");
            label7.Text = manager.GetString("regCliente_genero");
            label8.Text = manager.GetString("regCliente_apellido2");
            buttonReg.Text = manager.GetString("reg_boton");
            comboBoxGenero.Items.AddRange(new object[] { manager.GetString("Genero1"), manager.GetString("Genero2"), manager.GetString("Genero3") });
        }

        /// <summary>
        /// Obtiene las ids de Clientes existentes
        /// </summary>
        private void CargarIds()
        {
            textBoxID.Enabled = false;
            buttonReg.Enabled = false;
            panelErrorID.Visible = true;
            labelError.Text = manager.GetString("Reg_Cargando");
            clienteIDs = Program.datosSQL.ObtenerIdCliente();
            if (clienteIDs == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener Id de clientes");
                Program.bitacora.Nuevolog = true;
                labelError.Text = manager.GetString("Reg_ErrorDataBase");
                return;
            }
            panelErrorID.Visible = false;
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
            string id = textBoxID.Text;
            bool noesvalida;
            noesvalida = ExisteID(id); //llama a funcion para verificar si es unico en DB
            if (noesvalida)
            {
                buttonReg.Enabled = false;
                panelErrorID.Visible = true;
                labelError.Text = manager.GetString("Reg_IdYaExiste");
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
                char genero = ItemSeleccionado[0];
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
            { 
                panelErrorReg.Visible = true;
                labelErrorBtn.Text = manager.GetString("Reg_ErrorFaltaInfo");
            } //si no tiene los datos correctos o completos muestra error
        }
    }
}

using RestUnedAppCliente;
using System;
using System.Windows.Forms;
using RestUnedAppCliente.Server.Client;

namespace RestUnedAppCliente.Formularios.Sesion
{
    public partial class IniciarSesionCliente : Form
    {
        private bool isExplicitClose = false;
        public IniciarSesionCliente()
        {
            InitializeComponent();
            //esconde los paneles de error
            panelErrorReg.Visible = false;
            labelDenegado.Visible = false;
            labelFaltaInfo.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            Program.sesionExpirada = false;
        }
        
        /// <summary>
        /// Solicita al servidor autenticacion segun el id digita y permite o no el inicio del dahsboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReg_Click(object sender, EventArgs e)
        {
            Client cl = new Client();
            cl.CheckConexion();
            cl.CloseConnection();
            if (Program.conexionServidor)
            {
                if (!string.IsNullOrEmpty(textBoxID.Text)) //verifica que los datos esten completos y correctos antes de continuar
                {
                    bool esvalida;
                    string id = textBoxID.Text;
                    Client cliente = new Client();
                    esvalida = cliente.SolicitarAutenticacion(id); //solicita autenticacion
                    cliente.CloseConnection();
                    if (esvalida)
                    {
                        Client client = new Client();
                        Program.usuario = client.SolicitarUsuario(id); //solicita datos completos del cliente
                        client.CloseConnection();
                        panelErrorReg.Visible = false;
                        buttonReg.Enabled = false;
                        Program.iniciardashboard = true;
                        isExplicitClose = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El servidor a denegado al acceso. Usuario no valido. Intente denuevo", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //limpia el form
                        textBoxID.Text = "";
                        panelErrorReg.Visible = true;
                        labelDenegado.Visible = true;
                        labelFaltaInfo.Visible = false;
                    }
                }
                else//si no tiene los datos correctos o completos muestra error
                { 
                    panelErrorReg.Visible = true; labelFaltaInfo.Visible = true; 
                } 
            }
            else 
            {
                MessageBox.Show("No se ha podido conectar con el servidor. La aplicación se cerrará.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.iniciardashboard = false;
                isExplicitClose = true;
                this.Close();
            }
        }

        /// <summary>
        /// Permite controlar el cerrado de la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IniciarSesionCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExplicitClose && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Seleccione Yes para salir.", "Desea cerrar el programa?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                { Program.reiniciarApp = false; }
            }
        }
    }
}

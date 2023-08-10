///Elaborado por Emilio Serrano Sánchez
///Proyecto para la asignatura Programacion Avanzada 00830
///Universidad Estatal a Distancia, 2-2023
using System;
using System.Threading;
using System.Windows.Forms;
using RestUnedAppCliente.Server.Client;
using RestUnedAppCliente.Formularios.Cosultar;
using RestUnedAppCliente.Formularios.Registrar;

namespace RestUnedAppCliente.Formularios.MenuPrincipal
{
    public partial class Dashboard : Form
    {
        private bool isExplicitClose = false;
        public Dashboard()
        {
            InitializeComponent();
            ConeccionCheck_Click(null, EventArgs.Empty);
            string usu = (Program.usuario.Nombre + " " + Program.usuario.Primer_Apellido);
            buttonNombreUsu.Text = "Usuario: " + usu;
            diseñocustom();
            this.StartPosition = FormStartPosition.CenterScreen;
            StartSesionExpiradaThread();
        }

        /// <summary>
        /// Verifica el valor de la sesion
        /// </summary>
        private void CheckSesionExpirada()
        {
            while (true)
            {
                Thread.Sleep(1000);

                if (Program.sesionExpirada) //si se expira la sesion, se cierra el dashboard el ususario debe iniciar sesion otra vez
                {
                    isExplicitClose = true;
                    Program.iniciardashboard = false;
                    MessageBox.Show("Su sesión a expirado debido a inactividad", "Sesión expirada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate {
                            this.Close();
                        });
                    }
                    else
                    {
                        this.Close();
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// Inicia el thread de verificacion de sesion
        /// </summary>
        private void StartSesionExpiradaThread()
        {
            Thread thread = new Thread(CheckSesionExpirada);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// Cierra todos los paneles al inciar el dashboard
        /// </summary>
        private void diseñocustom() //esconde los submenus al iniciar el dashboard
        {
            panelSesion.Visible = false;
            panelPedido.Visible = false;
            panelConsultar.Visible = false;
        }

        /// <summary>
        /// Oculta un panel segun la seleccion
        /// </summary>
        private void OcultarSubMenuPanel() //esconde el submenu
        {
            if (panelSesion.Visible == true)
                panelSesion.Visible = false;
            if (panelPedido.Visible == true)
                panelPedido.Visible = false;
            if (panelConsultar.Visible == true)
                panelConsultar.Visible = false;
        }

        /// <summary>
        /// Muestra un panel segun la seleccion
        /// </summary>
        /// <param name="submenu"></param>
        private void MostrarSubMenuPanel(Panel submenu) //muestra el submenu respectivo 
        {
            if (submenu.Visible == false)
            {
                OcultarSubMenuPanel();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private Form formularioactivo = null;

        /// <summary>
        /// Carga un formulario dentro de el dashboard
        /// </summary>
        /// <param name="miniform"></param>
        private void cargarformcontenido(Form miniform) 
        {
            if (formularioactivo != null)
                formularioactivo.Close();//cierra el formulario actual
            formularioactivo = miniform; //establece el nuevo formulario como formularioactivo
            miniform.TopLevel = false;
            panelContenido.Controls.Add(miniform); //agrega el formularo al panel
            miniform.Show(); //muestra el formulario
        }

        /// <summary>
        /// Solicita un check de conexion y muestra el resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConeccionCheck_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            bool conexion;
            conexion = client.CheckSesion();//verifica la conexión con el servidor
            if (conexion == true)
            {
                ConeccionCheck.Text = "Conexión al servidor: Activa";
            }
            else
            {
                MessageBox.Show("El servidor a denegado al acceso.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConeccionCheck.Text = "Conexión al servidor: No Activa";
            }
            client.CloseConnection();
        }

        /// <summary>
        /// Cierra la sesion con el servidor y el dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            diseñocustom();
            Client client = new Client();
            client.SolicitarDesconexion();
            Program.pedido = null;
            Program.PedidoPendiente = false;
            Program.usuario = null;
            Program.IdSesion = "";
            Program.iniciardashboard = false;
            isExplicitClose = true;
            this.Close();
        }

        /// <summary>
        /// controla el panel de sesion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNombreUsu_Click(object sender, EventArgs e)
        {
            MostrarSubMenuPanel(panelSesion);
        }

        private void PedidoBttn_Click(object sender, EventArgs e)
        {
            MostrarSubMenuPanel(panelPedido);
        }

        private void ConsultarPedidoBttn_Click(object sender, EventArgs e)
        {
            MostrarSubMenuPanel(panelConsultar);
        }

        /// <summary>
        /// Inicia form para contruir pedido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConstruirPedido_click(object sender, EventArgs e)
        {
            if (Program.PedidoPendiente == false)
            {
                cargarformcontenido(new ConstruirPedido());
            }
            else
            {
                DialogResult result = MessageBox.Show($"Usted tiene un pedido sin procesar. Al continuar el pedido anterior será eliminado. Desea continuar?", "Confirmar Selección?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
                else 
                {
                    cargarformcontenido(new ConstruirPedido());
                }
            }
        }

        private void ProcesarPedidoBttn_Click(object sender, EventArgs e)
        {
            cargarformcontenido(new ProcesarPedido());
        }

        private void ConPedidoUni_Click(object sender, EventArgs e)
        {
            cargarformcontenido(new ConsultarPedidoUnico());
        }

        private void ConPedidosTodos_Click(object sender, EventArgs e)
        {
            cargarformcontenido(new ConsultarPedidoTodos());
        }

        /// <summary>
        /// Permite controlar el cierre de la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExplicitClose && e.CloseReason == CloseReason.UserClosing) //si el ususario toco el X para cerrar...
            {
                DialogResult result = MessageBox.Show("Seleccione (Yes) para salir.", "Desea cerrar el programa?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Program.reiniciarApp = false;
                    Client client = new Client();
                    client.SolicitarDesconexion();
                    e.Cancel = false;
                }
            }
        }

    }
}

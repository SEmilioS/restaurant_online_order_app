///Elaborado por Emilio Serrano Sánchez
///Proyecto para la asignatura Programacion Avanzada 00830
///Universidad Estatal a Distancia, 2-2023
using System;
using System.Threading;
using System.Windows.Forms;
using RestUnedApp.Formularios.Consulta;
using RestUnedApp.Formularios.Log;
using RestUnedApp.Formularios.Registro;

namespace RestUnedApp.Formularios.MenuPrincipal
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            diseñocustom();
            bitacora_click(null, EventArgs.Empty);
            usucuenta_click(null, EventArgs.Empty);
            IniciarCheckUsuariosThread();
        }

        /// <summary>
        /// Mantiene actualizado el contador de ususarios conectados
        /// </summary>
        private void CheckUsuariosConectados()
        {
            while (true)
            {
                Thread.Sleep(1000);

                int CuentaUsuarios = Program.usuariosautenticados;
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.UsuCuenta.Text = $"Usuarios conectados: {CuentaUsuarios}";
                    });
                }
                else
                {
                    this.UsuCuenta.Text = $"Usuarios conectados: {CuentaUsuarios}";
                }
            }
        }

        /// <summary>
        /// Inicia el thread para contador de usuarios
        /// </summary>
        private void IniciarCheckUsuariosThread()
        {
            Thread thread = new Thread(CheckUsuariosConectados);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// Esconde los submenus del dashboard al iniciar la App
        /// </summary>
        private void diseñocustom()
        {
            panelRegistrarSubMenu.Visible = false;
            panelConsultarSubMenu.Visible = false;
        }

        /// <summary>
        /// Esconde el submenu indicado
        /// </summary>
        private void OcultarSubMenuPanel()
        {
            if (panelRegistrarSubMenu.Visible == true)
                panelRegistrarSubMenu.Visible = false;
            if (panelConsultarSubMenu.Visible == true)
                panelConsultarSubMenu.Visible = false;
        }

        /// <summary>
        /// Muestra el submenu indicado
        /// </summary>
        /// <param name="submenu"></param>
        private void MostrarSubMenuPanel(Panel submenu)
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

        /// <summary>
        /// Muestra el submenu de Registras al recibir click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrarBoton_Click(object sender, EventArgs e)
        {
            MostrarSubMenuPanel(panelRegistrarSubMenu);
        }
        #region SubMenuRegistrar
        private void reg_restaurante(object sender, EventArgs e) //registrar restaurante
        {
            cargarformcontenido(typeof(RegRestaurante));
            OcultarSubMenuPanel();
        }

        private void reg_categoria(object sender, EventArgs e) //registrar categorias de plato
        {
            cargarformcontenido(typeof(RegCatPlato));
            OcultarSubMenuPanel();
        }

        private void reg_plato(object sender, EventArgs e) //Registrar platos
        {
            cargarformcontenido(typeof(RegPlato));
            OcultarSubMenuPanel();
        }

        private void reg_cliente(object sender, EventArgs e) //registrar clientes
        {
            cargarformcontenido(typeof(RegCliente));
            OcultarSubMenuPanel();
        }

        private void reg_platorest(object sender, EventArgs e) //registrar asociacion de platos
        {
            cargarformcontenido(typeof(RegPlatoRest));
            OcultarSubMenuPanel();
        }

        private void reg_extra(object sender, EventArgs e) //registrar extras
        {
            cargarformcontenido(typeof(RegExtra));
            OcultarSubMenuPanel();
        }
        #endregion

        /// <summary>
        /// Muestra el submenu de Consultar al recibir click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarBoton_Click(object sender, EventArgs e)
        {
            MostrarSubMenuPanel(panelConsultarSubMenu);
        }
        #region SubMenuConsultar
        private void con_restaurantes(object sender, EventArgs e) //consultar restaurantes
        {
            cargarformcontenido(typeof(ConRestaurante));
            OcultarSubMenuPanel();
        }

        private void con_categoria(object sender, EventArgs e) //consultar categorias
        {
            cargarformcontenido(typeof(ConCatPlato));
            OcultarSubMenuPanel();
        }

        private void con_platos(object sender, EventArgs e) //consultar platos
        {
            cargarformcontenido(typeof(ConPlato));
            OcultarSubMenuPanel();
        }

        private void con_clientes(object sender, EventArgs e) //consultar clientes
        {
            cargarformcontenido(typeof(ConCliente));
            OcultarSubMenuPanel();
        }

        private void con_platorest(object sender, EventArgs e) //consultar platos asociados
        {
            cargarformcontenido(typeof(ConPlatoRest));
            OcultarSubMenuPanel();
        }

        private void con_extras(object sender, EventArgs e) //consultar extras
        {
            cargarformcontenido(typeof(ConExtras));
            OcultarSubMenuPanel();
        }
        #endregion

        private Form formularioactivo = null;
        /// <summary>
        /// Carga un nuevo formulario dentro del dashboard
        /// </summary>
        /// <param name="miniform"></param>
        private void cargarformcontenido(Type formType)
        {
            if (formularioactivo != null)
                formularioactivo.Close();

            Form miniform = (Form)Activator.CreateInstance(formType); // Create a new instance of the form
            formularioactivo = miniform;
            miniform.TopLevel = false;
            panelContenido.Controls.Add(miniform);
            miniform.Show();
        }

        /// <summary>
        /// Muestra el fomulario bitacora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bitacora_click(object sender, EventArgs e)
        {
            cargarformcontenido(typeof(Bitacora));
        }

        /// <summary>
        /// Envia solicitud para actualizar contador de ususarios conectados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usucuenta_click(object sender, EventArgs e)
        {
            int CuentaUsuarios = Program.usuariosautenticados;
            UsuCuenta.Text = $"Usuarios conectados: {CuentaUsuarios}";
        }

        /// <summary>
        /// Cierra el servidor cuendo el dashboard se cierra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.server.Stop();
        }
    }
}

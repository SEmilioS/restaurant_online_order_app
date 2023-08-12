using RestOrderingClases;
using System;
using System.Windows.Forms;
using RestOrderingAppClient.Formularios.MenuPrincipal;
using RestOrderingAppClient.Formularios.Sesion;

namespace RestOrderingAppClient
{
    internal static class Program
    {
        public static Cliente usuario;
        public static string IdSesion;
        public static bool iniciardashboard;
        public static bool reiniciarApp;
        public static Pedido pedido;
        public static bool PedidoPendiente = false;
        public static bool sesionExpirada = false;
        public static bool conexionServidor;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            iniciardashboard = false;
            reiniciarApp = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //loop que permite el uso continuo de la app
            while (reiniciarApp == true)
            {
                if (iniciardashboard)
                {
                    using (var dashboardForm = new Dashboard())
                    {
                        Application.Run(dashboardForm);
                    }
                }
                else
                {
                    using (var iniciarSesionForm = new IniciarSesionCliente())
                    {
                        Application.Run(iniciarSesionForm);
                    }
                }
            }
        }
    }
}

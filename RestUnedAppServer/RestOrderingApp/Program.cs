using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestOrderingApp.Registro.Bitacora;
using RestOrderingApp.DataBase;
using RestOrderingApp.Formularios.MenuPrincipal;
using RestOrderingApp.Server;

namespace RestOrderingApp
{
    internal class Program
    {
        public static LogBitacora bitacora = new LogBitacora();
        public static int usuariosautenticados = 0;
        public static Servidor server = new Servidor();
        public static BaseDatosSQL datosSQL = new BaseDatosSQL();
        /// <summary>
        /// Inicia la applicacion.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ///prueba la conexion con la base de datos
            datosSQL.ProbarSqlConexion();
            /// Iniciar el servidor en un thread separado
            Task.Run(() =>
            {
                server.Start();

            });
            /// Abre el formulario GUI
            Application.Run(new Dashboard());
        }
    }
}

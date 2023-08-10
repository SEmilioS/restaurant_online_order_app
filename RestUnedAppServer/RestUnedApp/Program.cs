///Elaborado por Emilio Serrano Sánchez
///Proyecto para la asignatura Programacion Avanzada 00830
///Universidad Estatal a Distancia, 2-2023
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestUnedApp.Registro.Bitacora;
using RestUnedApp.DataBase;
using RestUnedApp.Formularios.MenuPrincipal;
using RestUnedApp.Server;

namespace RestUnedApp
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

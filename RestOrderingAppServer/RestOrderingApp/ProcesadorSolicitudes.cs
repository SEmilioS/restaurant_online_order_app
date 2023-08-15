using Newtonsoft.Json;
using RestOrderingClases;
using System;
using System.Linq;
using RestOrderingApp.Server.Sesiones;
using RestOrderingApp.Server.Autenticacion;
using System.Resources;

namespace RestOrderingApp.Server.Solicitudes
{
    internal class ProcesadorSolicitudes
    {
        private ResourceManager manager = new ResourceManager(typeof(Program));

        public ProcesadorSolicitudes()
        { 
            SelectorLenguaje sl = new SelectorLenguaje();
            manager = sl.CargarLenguaje();
        }
        /// <summary>
        /// Envia una confirmacion de conexion
        /// </summary>
        /// <returns></returns>
        public string PS_CheckConexion()
        {
            string responseMessage;
            Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M1")}");
            Program.bitacora.Nuevolog = true;
            responseMessage = "Conexión Activa";
            Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M2")}");
            Program.bitacora.Nuevolog = true;
            return responseMessage;
        }

        /// <summary>
        /// Autentica un usuario segun la Id de cliente proporcionada
        /// </summary>
        /// <param name="IDclientetcp"></param>
        /// <param name="adS"></param>
        /// <returns>
        /// Mesange indicando si se autentico + id de sesion o denagacion de autenticado
        /// </returns>
        public string PS_Autenticar(string IDclientetcp, AdministradorSesiones adS)
        {
            Autenticador autenticador = new Autenticador();
            string responseMessage;
            if (autenticador.AutenticarCliente(IDclientetcp)) //Verifica la id en la base de datos
            {
                string IdSesion = adS.GenerarIdSesion();
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M3")} {IdSesion}");
                Program.bitacora.Nuevolog = true;
                responseMessage = "Autenticada:" + IdSesion;
                return responseMessage;
            }
            else //el usuario no está registrado por lo que se le responde autentitcacion denegada
            {
                responseMessage = "Denegada";
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M4")}");
                Program.bitacora.Nuevolog = true;
                return responseMessage;
            }
        }

        /// <summary>
        /// Procesamiento de solicitudes de tipo 2 (Idsesion + Solicitud)
        /// </summary>
        /// <param name="solicitud"></param>
        /// <param name="IdSesion"></param>
        /// <returns></returns>
        public string PS_Tipo2(string solicitud, string IdSesion)
        {
            string responseMessage;
            switch (solicitud) //se envia una respuesta segun la solicitud
            {
                case "ObtenerPedidosIDs":
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M5")} {IdSesion} {manager.GetString("bitacora_ProcesadorS_M6")}");
                    Program.bitacora.Nuevolog = true;
                    int[] idspasadas = Program.datosSQL.ObtenerIdsNoDisponiblesPedidos();
                    responseMessage = JsonConvert.SerializeObject(idspasadas);
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M16")} {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "ObtenerRestArrr":
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M5")} {IdSesion} {manager.GetString("bitacora_ProcesadorS_M7")}");
                    Program.bitacora.Nuevolog = true;
                    Restaurante[] restaurantes = Program.datosSQL.ObtenerRestaurantes();
                    responseMessage = JsonConvert.SerializeObject(restaurantes);
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M17")} {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "ObtenerPlatRest":
                    Program.bitacora.Registros.Add($"{DateTime.Now}  {manager.GetString("bitacora_ProcesadorS_M5")} {IdSesion} {manager.GetString("bitacora_ProcesadorS_M8")}");
                    Program.bitacora.Nuevolog = true;
                    Restaurante[] rest = Program.datosSQL.ObtenerRestaurantes();
                    Plato[] plat = Program.datosSQL.ObtenerPlatos();
                    PlatoRestaurante[] platosRestaurantes = Program.datosSQL.ObtenerPlatoRest(rest, plat);
                    responseMessage = JsonConvert.SerializeObject(platosRestaurantes);
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M18")} {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "ObtenerExtras":
                    Program.bitacora.Registros.Add($"{DateTime.Now}  {manager.GetString("bitacora_ProcesadorS_M5")} {IdSesion} {manager.GetString("bitacora_ProcesadorS_M9")}");
                    Program.bitacora.Nuevolog = true;
                    Extra[] extras = Program.datosSQL.ObtenerExtras();
                    responseMessage = JsonConvert.SerializeObject(extras);
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M19")} {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "ObtenerPlatos":
                    Program.bitacora.Registros.Add($"{DateTime.Now}  {manager.GetString("bitacora_ProcesadorS_M5")} {IdSesion} {manager.GetString("bitacora_ProcesadorS_M10")}");
                    Program.bitacora.Nuevolog = true;
                    Plato[] platos = Program.datosSQL.ObtenerPlatos();
                    responseMessage = JsonConvert.SerializeObject(platos);
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M20")} {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "Check_Conexion":
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M5")} {IdSesion} {manager.GetString("bitacora_ProcesadorS_M11")}");
                    Program.bitacora.Nuevolog = true;
                    responseMessage = "Conexión Activa";
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M21")} {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "FinalizarConeccion":
                    Program.bitacora.Registros.Add($"{DateTime.Now}   {manager.GetString("bitacora_ProcesadorS_M5")} {IdSesion} {manager.GetString("bitacora_ProcesadorS_M12")}");
                    Program.bitacora.Nuevolog = true;
                    responseMessage = JsonConvert.SerializeObject("Conneccion terminada");
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M22")} {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                default:
                    responseMessage = "Solicitud invalida";
                    return responseMessage;
            }
        }

        /// <summary>
        /// Procesa un nuevo pedido enviandolo a la base de datos
        /// </summary>
        /// <param name="solicitud"></param>
        /// <param name="IdSesion"></param>
        /// <param name="pedido"></param>
        /// <returns>
        /// confirmacion
        /// </returns>
        public string PS_ProcesarPedido(string solicitud, string IdSesion, Pedido pedido)
        {
            string responseMessage;
            Program.bitacora.Registros.Add($"{DateTime.Now}   {manager.GetString("bitacora_ProcesadorS_M5")} {IdSesion} {manager.GetString("bitacora_ProcesadorS_M13")}");
            Program.bitacora.Nuevolog = true;
            bool estado = Program.datosSQL.agregarPedido(pedido);
            if (estado == true)
            {
                responseMessage = "PedidoProcesado";
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M23")} {IdSesion}");
                Program.bitacora.Nuevolog = true;
                return responseMessage;
            }
            else
            {
                responseMessage = "PedidoNoProcesado";
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M24")} {IdSesion}");
                Program.bitacora.Nuevolog = true;
                return responseMessage;
            }
        }

        /// <summary>
        /// Solicita a la DB los pedidos de un usuario 
        /// </summary>
        /// <param name="solicitud"></param>
        /// <param name="IdSesion"></param>
        /// <param name="usuID"></param>
        /// <returns>
        /// Objeto pedido o error
        /// </returns>
        public string PS_ObtenerPedidos(string solicitud, string IdSesion, string usuID)
        {
            string responseMessage;
            Program.bitacora.Registros.Add($"{DateTime.Now}   {manager.GetString("bitacora_ProcesadorS_M5")} {IdSesion} {manager.GetString("bitacora_ProcesadorS_M14")}");
            Program.bitacora.Nuevolog = true;
            Pedido[] pedidos = Program.datosSQL.ObtenerPedidosPorID(usuID);
            if (pedidos == null)
            {
                responseMessage = "ErorDBSQL";
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M25")} {IdSesion}");
                Program.bitacora.Nuevolog = true;
                return responseMessage;
            }
            else
            {
                responseMessage = JsonConvert.SerializeObject(pedidos);
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M26")} {IdSesion}");
                Program.bitacora.Nuevolog = true;
                return responseMessage;
            }
        }

        /// <summary>
        /// Obtiene una copia del objeto cliente para una id determinada
        /// </summary>
        /// <param name="solicitud"></param>
        /// <param name="IdSesion"></param>
        /// <param name="usuID"></param>
        /// <returns>
        /// Objeto cliente
        /// </returns>
        public string PS_ObtenerUsuario(string solicitud, string IdSesion, string usuID)
        {
            string responseMessage;
            Program.bitacora.Registros.Add($"{DateTime.Now}   {manager.GetString("bitacora_ProcesadorS_M5")} {IdSesion} {manager.GetString("bitacora_ProcesadorS_M15")}");
            Program.bitacora.Nuevolog = true;
            Cliente[] clientes = Program.datosSQL.ObtenerClientes();
            Cliente cl = clientes.FirstOrDefault(c => c.Identificacion == usuID); //crea una copia de la informacion en base a la id recibida
            responseMessage = JsonConvert.SerializeObject(cl);
            Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M27")} {IdSesion}");
            Program.bitacora.Nuevolog = true;
            return responseMessage;
        }

        /// <summary>
        /// Genera un mensaje de sesion invalida
        /// </summary>
        /// <returns></returns>
        public string PS_NoAutenticada()
        {
            string responseMessage = "Denegada";
            Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_ProcesadorS_M28")}");
            Program.bitacora.Nuevolog = true;
            return responseMessage;
        }
    }
}

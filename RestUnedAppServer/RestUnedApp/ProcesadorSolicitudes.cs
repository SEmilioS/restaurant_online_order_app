using Newtonsoft.Json;
using RestUnedClases;
using System;
using System.Linq;
using RestUnedApp.Server.Sesiones;
using RestUnedApp.Server.Autenticacion;

namespace RestUnedApp.Server.Solicitudes
{
    internal class ProcesadorSolicitudes
    {
        /// <summary>
        /// Envia una confirmacion de conexion
        /// </summary>
        /// <returns></returns>
        public string PS_CheckConexion()
        {
            string responseMessage;
            Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Rest-Uned-Cliente a solicitado check de conexión");
            Program.bitacora.Nuevolog = true;
            responseMessage = "Conexión Activa";
            Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado confirmacion de conexión a Rest-Uned-Cliente");
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
                Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha autenticado un cliente con Id de Sesión: {IdSesion}");
                Program.bitacora.Nuevolog = true;
                responseMessage = "Autenticada:" + IdSesion;
                return responseMessage;
            }
            else //el usuario no está registrado por lo que se le responde autentitcacion denegada
            {
                responseMessage = "Denegada";
                Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha denegado acceso a un Usuario no registrado en DB.");
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
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario: {IdSesion} a solicitado array Ids Pedidos pasados");
                    Program.bitacora.Nuevolog = true;
                    int[] idspasadas = Program.datosSQL.ObtenerIdsNoDisponiblesPedidos();
                    responseMessage = JsonConvert.SerializeObject(idspasadas);
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado array Ids de Pedidos Usadas a Usuario: {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "ObtenerRestArrr":
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario: {IdSesion} a solicitado array Restaurantes");
                    Program.bitacora.Nuevolog = true;
                    Restaurante[] restaurantes = Program.datosSQL.ObtenerRestaurantes();
                    responseMessage = JsonConvert.SerializeObject(restaurantes);
                    Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Se ha enviado array restuarante a Usuario: {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "ObtenerPlatRest":
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario: {IdSesion} a solicitado array PlatoRestaurante");
                    Program.bitacora.Nuevolog = true;
                    Restaurante[] rest = Program.datosSQL.ObtenerRestaurantes();
                    Plato[] plat = Program.datosSQL.ObtenerPlatos();
                    PlatoRestaurante[] platosRestaurantes = Program.datosSQL.ObtenerPlatoRest(rest, plat);
                    responseMessage = JsonConvert.SerializeObject(platosRestaurantes);
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado array PlatosRestaurante a Usuario: {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "ObtenerExtras":
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario: {IdSesion} a solicitado array Extras");
                    Program.bitacora.Nuevolog = true;
                    Extra[] extras = Program.datosSQL.ObtenerExtras();
                    responseMessage = JsonConvert.SerializeObject(extras);
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado array Extras a Usuario: {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "ObtenerPlatos":
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario: {IdSesion} a solicitado array Platos");
                    Program.bitacora.Nuevolog = true;
                    Plato[] platos = Program.datosSQL.ObtenerPlatos();
                    responseMessage = JsonConvert.SerializeObject(platos);
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado array Platos a Usuario: {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "Check_Conexion":
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario {IdSesion} a solicitado check de conexión");
                    Program.bitacora.Nuevolog = true;
                    responseMessage = "Conexión Activa";
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado confirmacion de conexión a Usuario {IdSesion}");
                    Program.bitacora.Nuevolog = true;
                    return responseMessage;

                case "FinalizarConeccion":
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario: {IdSesion} a solicitado desconexión.");
                    Program.bitacora.Nuevolog = true;
                    responseMessage = JsonConvert.SerializeObject("Conneccion terminada");
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha cerrado la conexión del Usuario: {IdSesion}");
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
            Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario: {IdSesion} a solicitado procesar un pedido");
            Program.bitacora.Nuevolog = true;
            bool estado = Program.datosSQL.agregarPedido(pedido);
            if (estado == true)
            {
                responseMessage = "PedidoProcesado";
                Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado confirmacion de Pedido Procesado al Usuario: {IdSesion}");
                Program.bitacora.Nuevolog = true;
                return responseMessage;
            }
            else
            {
                responseMessage = "PedidoNoProcesado";
                Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado error de Pedido Procesado al Usuario: {IdSesion}");
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
            Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario: {IdSesion} a solicitado informacion de Pedidos");
            Program.bitacora.Nuevolog = true;
            Pedido[] pedidos = Program.datosSQL.ObtenerPedidosPorID(usuID);
            if (pedidos == null)
            {
                responseMessage = "ErorDBSQL";
                Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado error de Pedidos consultados al Usuario: {IdSesion}");
                Program.bitacora.Nuevolog = true;
                return responseMessage;
            }
            else
            {
                responseMessage = JsonConvert.SerializeObject(pedidos);
                Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado informacion de Pedidos a Usuario: {IdSesion}");
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
            Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario: {IdSesion} a solicitado informacion de Cliente");
            Program.bitacora.Nuevolog = true;
            Cliente[] clientes = Program.datosSQL.ObtenerClientes();
            Cliente cl = clientes.FirstOrDefault(c => c.Identificacion == usuID); //crea una copia de la informacion en base a la id recibida
            responseMessage = JsonConvert.SerializeObject(cl);
            Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha enviado informacion de cliente a Usuario: {IdSesion}");
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
            Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Usuario no autenticado o sesión expirada; Se ha denegado respuesta.");
            Program.bitacora.Nuevolog = true;
            return responseMessage;
        }
    }
}

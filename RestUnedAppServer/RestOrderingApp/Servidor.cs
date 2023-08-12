using Newtonsoft.Json;
using RestOrderingClases;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Configuration;
using RestOrderingApp.Server.Solicitudes;
using RestOrderingApp.Server.Sesiones;

namespace RestOrderingApp.Server
{
    public class Servidor
    {
        private TcpListener tcpListener;
        private bool ServidorActivo = true;
        private AdministradorSesiones administradorSesiones;
        private ProcesadorSolicitudes procesadorSolicitudes;

        public Servidor()
        {
            // Establece el Ip i puerto del servidor
            string IPservidor = ConfigurationManager.AppSettings["ServerIP"];
            int puerto = int.Parse(ConfigurationManager.AppSettings["ServerPort"]);
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(IPservidor, puerto);
                    tcpClient.Close();
                }
                catch
                {
                    // Si se recibe error significa que el puerto esta libre y se puede continuar
                }
            }
            tcpListener = new TcpListener(IPAddress.Parse(IPservidor), puerto);
        }

        /// <summary>
        /// Inicia el servidor
        /// </summary>
        public void Start()
        {
            tcpListener.Start();
            Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Servidor iniciado. Esperando conecciones...");
            Program.bitacora.Nuevolog = true;
            administradorSesiones = new AdministradorSesiones();
            procesadorSolicitudes = new ProcesadorSolicitudes();

            try
            {
                while (ServidorActivo == true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha recibido una solicitud...");
                    Program.bitacora.Nuevolog = true;

                    //Crea un thread para resolver correctamente cada solicitud
                    Thread clientThread = new Thread(HandleClientCommunication);
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Error al aceptar solicitud recibida: " + ex.Message);
                Program.bitacora.Nuevolog = true;
            }
        }

        /// <summary>
        /// Detiene el servidor
        /// </summary>
        public void Stop()
        {
            tcpListener.Stop();
            ServidorActivo = false;
        }

        /// <summary>
        /// Procesa las solicitudes recibidas
        /// </summary>
        /// <param name="clientObj"></param>
        private void HandleClientCommunication(object clientObj)
        {
            TcpClient client = (TcpClient)clientObj;
            string IDclientetcp = null;
            string IdSesion = null;

            try
            {
                // Inicia el network stream donde se recibe y envia datos.
                NetworkStream stream = client.GetStream();

                // Recibe datos de la solicitud del cliente
                byte[] buffer = new byte[8096];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string solicitud = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                // Variable a utilizar para la respuesta del servidor
                string responseMessage = string.Empty;

                if (solicitud.StartsWith("Check_Conexion")) //Solicitud que verifica el estado de la conexion con el servidor
                {
                    responseMessage = procesadorSolicitudes.PS_CheckConexion();
                    byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                    stream.Write(responseData, 0, responseData.Length);
                    return;
                }

                if (solicitud.StartsWith("Autenticar:")) //Solicitud de autenticacion o Inicio de sesión
                {
                    IDclientetcp = solicitud.Substring("Autenticar:".Length); //Obtiene el id de Cliente contenido en la solicitud
                    responseMessage = procesadorSolicitudes.PS_Autenticar(IDclientetcp, administradorSesiones);
                    if (responseMessage != "Denegada")
                    {
                        IdSesion = responseMessage.Substring("Autenticada:".Length);
                        administradorSesiones.AgregarSesion(IdSesion);//agrega la sesion al diccionario
                    }
                    byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                    stream.Write(responseData, 0, responseData.Length);
                }

                if (solicitud.StartsWith("IdSesion:")) //Solicitudes que inician con IDSesion provienen de un Cliente autenticado
                {
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se recibió solicitud de cliente autenticado:");
                    Program.bitacora.Nuevolog = true;
                    //Informacion en la solicitud se divide en base a ";"
                    string[] PartesSolicitud = solicitud.Substring("IdSesion:".Length).Split(';');
                    solicitud = PartesSolicitud[1];

                    if (PartesSolicitud.Length == 3 && solicitud == "ObtenerUsuario") //solicitud de 3 partes para Obtener Objeto Cliente
                    {
                        IdSesion = PartesSolicitud[0];
                        solicitud = PartesSolicitud[1];
                        string usuID = PartesSolicitud[2];
                        if (!administradorSesiones.Check_Sesiones(IdSesion)) //antes de responder verifica la Id de sesion recibida
                        {
                            // Sesion invalida
                            responseMessage = procesadorSolicitudes.PS_NoAutenticada();
                            byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                            stream.Write(responseData, 0, responseData.Length);
                            return;
                        }
                        else //Sesion es valida
                        {
                            administradorSesiones.MantenerSesion(IdSesion);
                            responseMessage = procesadorSolicitudes.PS_ObtenerUsuario(solicitud, IdSesion, usuID);
                            byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                            stream.Write(responseData, 0, responseData.Length);
                        }
                    }
                    else if (PartesSolicitud.Length == 3 && solicitud == "ProcesarPedido") //solicitud de 3 partes para Procesar Pedido 
                    {
                        IdSesion = PartesSolicitud[0];
                        Pedido pedido = JsonConvert.DeserializeObject<Pedido>(PartesSolicitud[2]);
                        if (!administradorSesiones.Check_Sesiones(IdSesion)) //antes de responder verifica la Id de sesion recibida
                        {
                            // Sesion invalida
                            responseMessage = procesadorSolicitudes.PS_NoAutenticada();
                            byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                            stream.Write(responseData, 0, responseData.Length);
                            return;
                        }
                        else //Sesion es valida
                        {
                            administradorSesiones.MantenerSesion(IdSesion);
                            responseMessage = procesadorSolicitudes.PS_ProcesarPedido(solicitud, IdSesion, pedido);
                            byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                            stream.Write(responseData, 0, responseData.Length);
                            return;
                        }
                    }
                    else if (PartesSolicitud.Length == 3 && solicitud == "ObtenerPedidos") //request de 3 partes para Consultar Pedidos
                    {
                        IdSesion = PartesSolicitud[0];
                        solicitud = PartesSolicitud[1];
                        string usuID = PartesSolicitud[2];
                        if (!administradorSesiones.Check_Sesiones(IdSesion)) //antes de responder verifica la Id de sesion recibida
                        {
                            // Sesion invalida
                            responseMessage = procesadorSolicitudes.PS_NoAutenticada();
                            byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                            stream.Write(responseData, 0, responseData.Length);
                            return;
                        }
                        else //Sesion es valida
                        {
                            administradorSesiones.MantenerSesion(IdSesion);
                            responseMessage = procesadorSolicitudes.PS_ObtenerPedidos(solicitud, IdSesion, usuID);
                            byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                            stream.Write(responseData, 0, responseData.Length);
                            return;
                        }
                    }
                    else if (PartesSolicitud.Length == 2) //solicitud de dos partes (Tipo 2)
                    {
                        IdSesion = PartesSolicitud[0];
                        solicitud = PartesSolicitud[1];

                        if (!administradorSesiones.Check_Sesiones(IdSesion))
                        {
                            // Sesion invalida
                            responseMessage = procesadorSolicitudes.PS_NoAutenticada();
                            byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                            stream.Write(responseData, 0, responseData.Length);
                            return;
                        }
                        else
                        {
                            if (solicitud == "FinalizarConeccion")
                            {
                                responseMessage = procesadorSolicitudes.PS_Tipo2(solicitud, IdSesion);
                                administradorSesiones.EliminarSesion(IdSesion);
                            }
                            else
                            {
                                administradorSesiones.MantenerSesion(IdSesion);
                                responseMessage = procesadorSolicitudes.PS_Tipo2(solicitud, IdSesion);
                            }
                            // envia la respuesta
                            byte[] responseData = Encoding.ASCII.GetBytes(responseMessage);
                            stream.Write(responseData, 0, responseData.Length);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Error al procesar solicitud: " + ex.Message);
                Program.bitacora.Nuevolog = true;
            }
        }

    }
}

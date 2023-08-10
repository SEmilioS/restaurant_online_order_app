///Elaborado por Emilio Serrano Sánchez
///Proyecto para la asignatura Programacion Avanzada 00830
///Universidad Estatal a Distancia, 2-2023
using Newtonsoft.Json;
using RestUnedClases;
using System;
using System.Configuration;
using System.Net.Sockets;
using System.Text;

namespace RestUnedAppCliente.Server.Client
{
    public class Client
    {
        private TcpClient tcpClient;

        public Client()
        {
            // Establece el Ip y el puerto
            string serverIp = ConfigurationManager.AppSettings["ServerIP"];
            int port = int.Parse(ConfigurationManager.AppSettings["ServerPort"]);

            //Crea el tcpCliente a utilizar
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(serverIp, port);
                Program.conexionServidor = true;
            }
            catch
            {
                Console.WriteLine("Error al conectar con el servidor");
                Program.reiniciarApp = false;
                Program.conexionServidor = false;
            }
        }

        /// <summary>
        /// Solicita al servidor autenticacion de ususario y una Id de Sesion 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SolicitarAutenticacion(string id)
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                string requestMessage = "Autenticar:" + id;
                byte[] requestData = Encoding.ASCII.GetBytes(requestMessage);
                stream.Write(requestData, 0, requestData.Length);

                byte[] responseBytes = new byte[1024];
                int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
                string responseMessage = Encoding.ASCII.GetString(responseBytes, 0, bytesRead);

                if (responseMessage.StartsWith("Autenticada:"))
                {
                    Program.IdSesion = responseMessage.Substring("Autenticada:".Length);
                    Console.WriteLine(Program.IdSesion);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de autenticación: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Solicita un objeto Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente SolicitarUsuario(string id)
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                string requestMessage = IncluirIdSesionEnSolicitud("ObtenerUsuario" + ";" + id);
                byte[] requestData = Encoding.ASCII.GetBytes(requestMessage);

                stream.Write(requestData, 0, requestData.Length);

                byte[] responseData = new byte[4096];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string responseMessage = Encoding.ASCII.GetString(responseData, 0, bytesRead);

                Cliente ususario = JsonConvert.DeserializeObject<Cliente>(responseMessage);
                return ususario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Solicita verificar conexion
        /// </summary>
        /// <returns></returns>
        public bool CheckConexion()
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                byte[] requestBytes = Encoding.ASCII.GetBytes("Check_Conexion");

                stream.Write(requestBytes, 0, requestBytes.Length);

                byte[] responseBytes = new byte[1024];
                int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
                string response = Encoding.ASCII.GetString(responseBytes, 0, bytesRead);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking connection: " + ex.Message);
                return false;
            }
        }

        public bool CheckSesion()
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                string requestMessage = IncluirIdSesionEnSolicitud("Check_Conexion");
                byte[] requestBytes = Encoding.ASCII.GetBytes(requestMessage);

                stream.Write(requestBytes, 0, requestBytes.Length);

                byte[] responseBytes = new byte[1024];
                int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
                string response = Encoding.ASCII.GetString(responseBytes, 0, bytesRead);
                if (response == "Denegada")
                {
                    Program.sesionExpirada = true;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking connection: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Solicita Array Restaurantes
        /// </summary>
        /// <returns></returns>
        public Restaurante[] SolicitarRestaurantes()
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                string requestMessage = IncluirIdSesionEnSolicitud("ObtenerRestArrr");
                byte[] requestData = Encoding.ASCII.GetBytes(requestMessage);

                stream.Write(requestData, 0, requestData.Length);

                byte[] responseData = new byte[8096];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string responseMessage = Encoding.ASCII.GetString(responseData, 0, bytesRead);
                if (responseMessage == "Denegada")
                {
                    Program.sesionExpirada = true;
                    return null;
                }
                else
                {
                    Restaurante[] restaurantes = JsonConvert.DeserializeObject<Restaurante[]>(responseMessage);
                    return restaurantes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Solicita Array PlatoRestaurante
        /// </summary>
        /// <returns></returns>
        public PlatoRestaurante[] SolicitarPlatoRest()
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                string requestMessage = IncluirIdSesionEnSolicitud("ObtenerPlatRest");
                byte[] requestData = Encoding.ASCII.GetBytes(requestMessage);

                stream.Write(requestData, 0, requestData.Length);

                byte[] responseData = new byte[8096];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string responseMessage = Encoding.ASCII.GetString(responseData, 0, bytesRead);
                if (responseMessage == "Denegada")
                {
                    Program.sesionExpirada = true;
                    return null;
                }
                else
                {
                    PlatoRestaurante[] pr = JsonConvert.DeserializeObject<PlatoRestaurante[]>(responseMessage);
                    return pr;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Solicita Array Extras
        /// </summary>
        /// <returns></returns>
        public Extra[] SolicitarExtras()
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                string requestMessage = IncluirIdSesionEnSolicitud("ObtenerExtras");
                byte[] requestData = Encoding.ASCII.GetBytes(requestMessage);

                stream.Write(requestData, 0, requestData.Length);

                byte[] responseData = new byte[8096];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string responseMessage = Encoding.ASCII.GetString(responseData, 0, bytesRead);
                if (responseMessage == "Denegada")
                {
                    Program.sesionExpirada = true;
                    return null;
                }
                else
                {
                    Extra[] extra = JsonConvert.DeserializeObject<Extra[]>(responseMessage);
                    return extra;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Solicita Array Platos
        /// </summary>
        /// <returns></returns>
        public Plato[] SolicitarPlatos()
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                string requestMessage = IncluirIdSesionEnSolicitud("ObtenerPlatos");
                byte[] requestData = Encoding.ASCII.GetBytes(requestMessage);

                stream.Write(requestData, 0, requestData.Length);

                byte[] responseData = new byte[8096];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string responseMessage = Encoding.ASCII.GetString(responseData, 0, bytesRead);
                if (responseMessage == "Denegada")
                {
                    Program.sesionExpirada = true;
                    return null;
                }
                else
                {
                    Plato[] platos = JsonConvert.DeserializeObject<Plato[]>(responseMessage);
                    return platos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Solicita procesamiento de Pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        public bool ProcesarPedido(Pedido pedido)
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                string serializedPedido = JsonConvert.SerializeObject(pedido);
                string requestMessage = IncluirIdSesionEnSolicitud("ProcesarPedido") + ";" + serializedPedido;
                byte[] requestData = Encoding.ASCII.GetBytes(requestMessage);

                stream.Write(requestData, 0, requestData.Length);

                byte[] responseBytes = new byte[8096];
                int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
                string responseMessage = Encoding.ASCII.GetString(responseBytes, 0, bytesRead);
                if (responseMessage == "PedidoProcesado")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing pedido: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Solicita Array de Pedidos
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public Pedido[] SolicitarPedidos(string idCliente)
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                string requestMessage = IncluirIdSesionEnSolicitud("ObtenerPedidos") + ";" + idCliente;
                byte[] requestData = Encoding.ASCII.GetBytes(requestMessage);

                stream.Write(requestData, 0, requestData.Length);

                byte[] responseBytes = new byte[8096];
                int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
                string responseMessage = Encoding.ASCII.GetString(responseBytes, 0, bytesRead);
                if (responseMessage == "Denegada")
                {
                    Program.sesionExpirada = true;
                    return null;
                }
                else if (responseMessage.StartsWith("ErrorDBSQL"))
                {
                    return null;
                }
                else
                {
                    Pedido[] pedido = JsonConvert.DeserializeObject<Pedido[]>(responseMessage);
                    return pedido;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Crea un formato de solicitud dividido por ";"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string IncluirIdSesionEnSolicitud(string request)
        {
            return "IdSesion:" + Program.IdSesion + ";" + request;
        }

        /// <summary>
        /// Solicita Desconexion
        /// </summary>
        public void SolicitarDesconexion()
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();

                string requestMessage = IncluirIdSesionEnSolicitud("FinalizarConeccion");
                byte[] requestBytes = Encoding.ASCII.GetBytes(requestMessage);

                stream.Write(requestBytes, 0, requestBytes.Length);

                byte[] responseBytes = new byte[1024];
                int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
                string response = Encoding.ASCII.GetString(responseBytes, 0, bytesRead);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al solicitar desconexion: " + ex.Message);
            }
        }

        /// <summary>
        /// Cierra la conexion tcp
        /// </summary>
        public void CloseConnection()
        {
            tcpClient.Close();
        }
    }
}
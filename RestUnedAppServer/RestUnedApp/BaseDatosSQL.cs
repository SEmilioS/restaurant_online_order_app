using RestUnedClases;
using System;
using System.Data.SqlClient;
using System.Threading;
using RestUnedApp.DataBase.Lectura;
using RestUnedApp.DataBase.Escritura;
using System.Configuration;

namespace RestUnedApp.DataBase
{
    public class BaseDatosSQL
    {
        private static Semaphore semaforoConsulta = new Semaphore(6, 6);
        private static Semaphore semaforoEscritura = new Semaphore(1, 1);
        private static string StringConexion;
        private LectorBaseDatos lector;
        private EscritorBaseDatos escritor;

        /// <summary>
        /// Constructor de Base de datos
        /// </summary>
        public BaseDatosSQL()
        {
            StringConexion = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            lector = new LectorBaseDatos(StringConexion, semaforoConsulta);
            escritor = new EscritorBaseDatos(StringConexion, semaforoEscritura);
        }

        /// <summary>
        /// Query para revisar conexion con DB
        /// </summary>
        public void ProbarSqlConexion()
        {
            try
            {
                semaforoConsulta.WaitOne();
                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    string log = $"{DateTime.Now} BaseDatosSQL: Conexión a la base de datos existosa.";
                    Program.bitacora.Registros.Add(log);
                }
            }
            catch (Exception ex)
            {
                string log = $"{DateTime.Now} BaseDatosSQL: Error al conectar con la base de datos: " + ex.Message;
                Program.bitacora.Registros.Add(log);
            }
            finally
            {
                semaforoConsulta.Release();
            }
        }

        #region Consultar

        /// <summary>
        /// Obtiene las ids de una tabla
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>
        /// Array int[] con todas las id de la tabla especificada
        /// </returns>
        public int[] ObtenerIDs(string tipo)
        {
            return lector.ObtenerIDs(tipo);
        }

        /// <summary>
        /// Obtiene las Ids de los clientes
        /// </summary>
        /// <returns>
        /// Array string[] con todas la ids de la tabla Cliente
        /// </returns>
        public string[] ObtenerIdCliente()
        {
            return lector.ObtenerIdCliente();
        }

        /// <summary>
        /// Obtiene los Restaurantes registrados
        /// </summary>
        /// <returns>
        /// Array Restaurante[] con todos los restaurante de la tabla Restaurante
        /// </returns>
        public Restaurante[] ObtenerRestaurantes()
        {
            return lector.ObtenerRestaurantes();
        }

        /// <summary>
        /// Obtiene los Platos registrados
        /// </summary>
        /// <returns>
        /// Array Plato[] con todos los platos registrado en la tabla Plato
        /// </returns>
        public Plato[] ObtenerPlatos()
        {
            return lector.ObtenerPlatos();
        }

        /// <summary>
        /// Obtiene las Categorias registradas
        /// </summary>
        /// <returns>
        /// Array CategoriaPlato[] con todas las categorias registradas en la tabla CategoriaPlato
        /// </returns>
        public CategoriaPlato[] ObtenerCategorias()
        {
            return lector.ObtenerCategorias();
        }

        /// <summary>
        /// Obtiene los Clientes registrados
        /// </summary>
        /// <returns>
        /// Array Cliente[] con todos los clientes registrados en la tabla Cliente
        /// </returns>
        public Cliente[] ObtenerClientes()
        {
            return lector.ObtenerClientes();
        }

        /// <summary>
        /// Obtiene las Extras registradas
        /// </summary>
        /// <returns>
        /// Array Extra[] con todas las extras registradas en la tabla Extra
        /// </returns>
        public Extra[] ObtenerExtras()
        {
            return lector.ObtenerExtras();
        }

        /// <summary>
        /// Obtiene los registros de PlatoRestaurante
        /// </summary>
        /// <param name="rest"></param>
        /// <param name="plat"></param>
        /// <returns>
        /// Array PlatoRestaurante[] con todos los registros de la tabla PlatoRestaurante
        /// </returns>
        public PlatoRestaurante[] ObtenerPlatoRest(Restaurante[] rest, Plato[] plat)
        {
            return lector.ObtenerPlatoRest(rest, plat);
        }

        /// <summary>
        /// obtiene los id de pedidos pasados
        /// </summary>
        /// <returns>
        /// Array int[] con todas las Id ya usuadas en pedidos
        /// </returns>
        public int[] ObtenerIdsNoDisponiblesPedidos()
        {
            return lector.ObtenerIdsNoDisponiblesPedidos();
        }

        /// <summary>
        /// Obtiene todos los Pedidos relacionados a un usuario
        /// </summary>
        /// <param name="usuID"></param>
        /// <returns>
        /// Array Pedido[] con todos los pedidos relacionados a usuID
        /// </returns>
        public Pedido[] ObtenerPedidosPorID(string usuID)
        {
            return lector.ObtenerPedidosPorID(usuID);
        }

        #endregion

        #region Registrar

        /// <summary>
        /// Agrega un restaurante a la DB
        /// </summary>
        /// <param name="restaurante"></param>
        public void agregarrestaurante(Restaurante restaurante)
        {
            escritor.agregarrestaurante(restaurante);
        }

        /// <summary>
        /// Agrega CategoriaPlato a la DB
        /// </summary>
        /// <param name="categoria"></param>
        public void agregarcategoriaplato(CategoriaPlato categoria)//agrega una Categoria a la DB
        {
            escritor.agregarcategoriaplato(categoria);
        }

        /// <summary>
        /// Agrega Plato a la DB
        /// </summary>
        /// <param name="plato"></param>
        public void agregarplato(Plato plato)
        {
            escritor.agregarplato(plato);
        }

        /// <summary>
        /// Agrega un Cliente a la DB
        /// </summary>
        /// <param name="cliente"></param>
        public void agregarcliente(Cliente cliente)
        {
            escritor.agregarcliente(cliente);
        }

        /// <summary>
        /// Agrega registro PlatoRestaurante a la DB
        /// </summary>
        /// <param name="platoRestaurante"></param>
        public void agregarplatorest(PlatoRestaurante platoRestaurante)
        {
            escritor.agregarplatorest(platoRestaurante);
        }

        /// <summary>
        /// Agrega Extra a la DB
        /// </summary>
        /// <param name="ex"></param>
        public void agregarextra(Extra ex)
        {
            escritor.agregarextra(ex);
        }

        /// <summary>
        /// Agrega un Pedido a la DB
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns>
        /// Boolean que indica si el agregado fue existoso
        /// </returns>
        public bool agregarPedido(Pedido pedido)
        {
            int[] ids = ObtenerIDs("Pedido");
            return escritor.agregarPedido(pedido, ids);
        }
        #endregion Registrar
    }
}

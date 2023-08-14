using RestOrderingClases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Resources;

namespace RestOrderingApp.DataBase.Lectura
{
    internal class LectorBaseDatos
    {
        private static string StringConexion;
        private Semaphore semaforoConsulta;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public LectorBaseDatos(string Conexion, Semaphore semaforo)
        {
            StringConexion = Conexion;
            semaforoConsulta = semaforo;
            SelectorLenguaje sl = new SelectorLenguaje();
            manager = sl.CargarLenguaje();
        }

        /// <summary>
        /// Obtiene las ids de una tabla
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>
        /// Array int[] con todas las id de la tabla especificada
        /// </returns>
        public int[] ObtenerIDs(string tipo)
        {
            string query = null;

            switch (tipo)
            {
                case "Restaurante":
                    query = "SELECT IdRestaurante FROM Restaurante";
                    break;
                case "Plato":
                    query = "SELECT IdPlato FROM Plato";
                    break;
                case "Categoria_SinEstado":
                    query = "SELECT IdCategoria FROM CategoriaPlato";
                    break;
                case "Categoria":
                    query = "SELECT IdCategoria FROM CategoriaPlato WHERE Estado = 1";
                    break;
                case "Extra":
                    query = "SELECT IdExtra FROM Extra";
                    break;
                case "Pedido":
                    query = "SELECT IdPedido FROM Pedido";
                    break;
                default:
                    return new int[0]; // Tipo invalido devuelve array vacia
            }

            try
            {
                semaforoConsulta.WaitOne(); // Espera en semaforo

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccess")} ObtenerIDs");
                    Program.bitacora.Nuevolog = true;
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        List<int> idList = new List<int>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                idList.Add(id);
                            }
                        }
                        return idList.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerIDs(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release(); //Liberar espacio en semaforo
            }
        }

        /// <summary>
        /// Obtiene las Ids de los clientes
        /// </summary>
        /// <returns>
        /// Array string[] con todas la ids de la tabla Cliente
        /// </returns>
        public string[] ObtenerIdCliente()
        {
            try
            {
                semaforoConsulta.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    string query = "SELECT IdCliente FROM Cliente";
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccess")} ObtenerIdCliente()");
                    Program.bitacora.Nuevolog = true;

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        List<string> idList = new List<string>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader.GetString(0);
                                idList.Add(id);
                            }
                        }
                        return idList.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerIdCliente(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release();
            }
        }

        /// <summary>
        /// Obtiene los Restaurantes registrados
        /// </summary>
        /// <returns>
        /// Array Restaurante[] con todos los restaurante de la tabla Restaurante
        /// </returns>
        public Restaurante[] ObtenerRestaurantes()
        {
            string query = "SELECT IdRestaurante, Nombre, Direccion, Estado, Telefono FROM Restaurante";

            try
            {
                semaforoConsulta.WaitOne(); // Espara espacio semaforo

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccess")} ObtenerRestaurantes()");
                    Program.bitacora.Nuevolog = true;

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        List<Restaurante> restauranteList = new List<Restaurante>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nombre = reader.GetString(1);
                                string direccion = reader.GetString(2);
                                bool estado = reader.GetBoolean(3);
                                string telefono = reader.GetString(4);

                                Restaurante restaurante = new Restaurante(id, nombre, direccion, estado, telefono);
                                restauranteList.Add(restaurante);
                            }
                        }
                        return restauranteList.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerRestaurantes(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release(); // Release the semaphore
            }
        }

        /// <summary>
        /// Obtiene los Platos registrados
        /// </summary>
        /// <returns>
        /// Array Plato[] con todos los platos registrado en la tabla Plato
        /// </returns>
        public Plato[] ObtenerPlatos()
        {
            string query = "SELECT IdPlato, Nombre, IdCategoria, Precio FROM Plato";

            try
            {
                semaforoConsulta.WaitOne();
                CategoriaPlato[] categorias = ObtenerCategorias();
                if (categorias == null)
                {
                    MessageBox.Show("Operacion abortada. Categoria no exitente en la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerPlatos()");
                    Program.bitacora.Nuevolog = true;
                    return null;
                }

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccess")} ObtenerPlatos()");
                    Program.bitacora.Nuevolog = true;

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        List<Plato> platoList = new List<Plato>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nombre = reader.GetString(1);
                                int categoriaId = reader.GetInt32(2);
                                int precio = reader.GetInt32(3);

                                CategoriaPlato categoria = categorias.FirstOrDefault(cat => cat.ID == categoriaId);
                                Plato plato = new Plato(id, nombre, precio, categoria);
                                platoList.Add(plato);
                            }
                        }
                        return platoList.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerPlatos(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release();
            }
        }

        /// <summary>
        /// Obtiene las Categorias registradas
        /// </summary>
        /// <returns>
        /// Array CategoriaPlato[] con todas las categorias registradas en la tabla CategoriaPlato
        /// </returns>
        public CategoriaPlato[] ObtenerCategorias()
        {
            string query = "SELECT IdCategoria, Descripcion, Estado FROM CategoriaPlato";

            try
            {
                semaforoConsulta.WaitOne(); // Espera semaforo

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccess")} ObtenerCategorias");
                    Program.bitacora.Nuevolog = true;

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        List<CategoriaPlato> restauranteList = new List<CategoriaPlato>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string descripcion = reader.GetString(1);
                                bool estado = reader.GetBoolean(2);

                                CategoriaPlato categoria = new CategoriaPlato(id, descripcion, estado);
                                restauranteList.Add(categoria);
                            }
                        }
                        return restauranteList.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerRestaurantes(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release();
            }
        }

        /// <summary>
        /// Obtiene los Clientes registrados
        /// </summary>
        /// <returns>
        /// Array Cliente[] con todos los clientes registrados en la tabla Cliente
        /// </returns>
        public Cliente[] ObtenerClientes()
        {
            string query = "SELECT IdCliente, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Genero FROM Cliente";

            try
            {
                semaforoConsulta.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccess")} ObtenerClientes()");
                    Program.bitacora.Nuevolog = true;

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        List<Cliente> clienteList = new List<Cliente>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader.GetString(0);
                                string nombre = reader.GetString(1);
                                string primerApellido = reader.GetString(2);
                                string segundoApellido = reader.GetString(3);
                                DateTime fechaNacimiento = reader.GetDateTime(4);
                                string genero = reader.GetString(5);
                                char gene = genero[0];

                                Cliente cliente = new Cliente(id, nombre, primerApellido, segundoApellido, fechaNacimiento, gene);
                                clienteList.Add(cliente);
                            }
                        }
                        return clienteList.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerClientes(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release(); // Release the semaphore
            }
        }

        /// <summary>
        /// Obtiene las Extras registradas
        /// </summary>
        /// <returns>
        /// Array Extra[] con todas las extras registradas en la tabla Extra
        /// </returns>
        public Extra[] ObtenerExtras()
        {
            string query = "SELECT IdExtra, Descripcion, IdCategoria, Estado, Precio FROM Extra";

            try
            {
                semaforoConsulta.WaitOne();
                CategoriaPlato[] categorias = ObtenerCategorias();
                if (categorias == null)//si no hay categorias no se puede continuar 
                {
                    MessageBox.Show( manager.GetString("lectorDB_M1_info"), manager.GetString("lectorDB_M1_tipo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerExtras()");
                    Program.bitacora.Nuevolog = true;
                    return null;
                }

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccess")} ObtenerExtras()");
                    Program.bitacora.Nuevolog = true;

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        List<Extra> extraList = new List<Extra>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string descripcion = reader.GetString(1);
                                int categoriaId = reader.GetInt32(2);
                                bool estado = reader.GetBoolean(3);
                                int precio = reader.GetInt32(4);

                                CategoriaPlato categoria = categorias.FirstOrDefault(cat => cat.ID == categoriaId);

                                Extra extra = new Extra(id, descripcion, categoria, estado, precio);
                                extraList.Add(extra);
                            }
                        }
                        return extraList.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerExtras(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release();
            }
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
            string query = "SELECT IdAsignacion, IdRestaurante, IdPlato, FechaAsignacion FROM PlatoRestaurante";

            try
            {
                semaforoConsulta.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccess")} ObtenerPlatoRest()");
                    Program.bitacora.Nuevolog = true;

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        List<PlatoRestaurante> platoRestList = new List<PlatoRestaurante>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int IdAsignadaActual = -1;
                            List<Plato> platosList = new List<Plato>();
                            Restaurante restaurante = null;
                            DateTime fechaHora = DateTime.MinValue;

                            while (reader.Read())
                            {
                                int idAsignacion = reader.GetInt32(0);
                                int idRestaurante = reader.GetInt32(1);
                                int idPlato = reader.GetInt32(2);
                                fechaHora = reader.GetDateTime(3);

                                restaurante = rest.FirstOrDefault(r => r.ID == idRestaurante); //obtiene objeto restaurante al buscar relacion con Id

                                Plato plato = plat.FirstOrDefault(p => p.ID == idPlato); //obtiene objeto Plato al buscar relacion con id

                                if (IdAsignadaActual != idAsignacion)
                                {
                                    if (IdAsignadaActual != -1)
                                    {
                                        PlatoRestaurante platoRest = new PlatoRestaurante(IdAsignadaActual, restaurante, fechaHora, platosList.ToArray());
                                        platoRestList.Add(platoRest);
                                    }

                                    platosList = new List<Plato>();
                                    IdAsignadaActual = idAsignacion;
                                }

                                platosList.Add(plato);
                            }

                            if (IdAsignadaActual != -1)
                            {
                                PlatoRestaurante platoRest = new PlatoRestaurante(IdAsignadaActual, restaurante, fechaHora, platosList.ToArray());
                                platoRestList.Add(platoRest);
                            }
                        }

                        return platoRestList.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerPlatoRest(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release(); // Release the semaphore
            }
        }

        /// <summary>
        /// obtiene los id de pedidos pasados
        /// </summary>
        /// <returns>
        /// Array int[] con todas las Id ya usuadas en pedidos
        /// </returns>
        public int[] ObtenerIdsNoDisponiblesPedidos()
        {
            string query = "SELECT IdPedido FROM Pedido";
            try
            {
                semaforoConsulta.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccess")} ObtenerIdsNoDisponiblesPedidos() ");
                    Program.bitacora.Nuevolog = true;
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        List<int> idList = new List<int>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) //por cada id encotrda se agrega al registro
                            {
                                int id = reader.GetInt32(0);
                                idList.Add(id);
                            }
                        }
                        idList = idList.Distinct().ToList(); //remueve las ids repetitas

                        return idList.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerIdsNoDisponiblesPedidos(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return new int[] { 0 };
            }
            finally
            {
                semaforoConsulta.Release();
            }
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
            Cliente[] clientes = ObtenerClientes();
            Plato[] platos = ObtenerPlatos();
            Extra[] extras = ObtenerExtras();

            List<Pedido> pedidosList = new List<Pedido>();

            // Obtiene todos los IdPedido que se relacionan con el cliente
            int[] idPedidos = ObtenerIdPedidosPorCliente(usuID);

            // Por cada IdPedido, se obtiene el ExtraPedido y luego se obtiene el Pedido
            foreach (int idPedido in idPedidos)
            {
                ExtraPedido[] extraPedidos = ObtenerExtraPedidosPorIdPedido(idPedido, extras, platos);
                if (extraPedidos == null)
                {
                    return null;
                }
                Pedido pedido = ObtenerPedidoPorId(idPedido, clientes, platos, extras, extraPedidos);
                if (pedido == null)
                {
                    return null;
                }
                pedidosList.Add(pedido);
            }
            return pedidosList.ToArray();
        }

        /// <summary>
        /// Submetodo para ObternerPedidos()
        /// </summary>
        /// <param name="usuID"></param>
        /// <returns>
        /// Array int[] con todos los Idpedidos relacionados al usuID
        /// </returns>
        private int[] ObtenerIdPedidosPorCliente(string usuID)
        {
            string query = "SELECT DISTINCT IdPedido FROM Pedido WHERE IdCliente = @usuID";

            HashSet<int> idPedidosSet = new HashSet<int>(); //asegura que no se repitan las idPedidos

            try
            {
                semaforoConsulta.WaitOne();
                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@usuID", usuID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idPedido = reader.GetInt32(0);
                                idPedidosSet.Add(idPedido);
                            }
                        }
                    }
                }
                return idPedidosSet.ToArray();
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerIdPedidosPorCliente(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release();
            }
        }

        /// <summary>
        /// Submetodo para ObtenerPedidos()
        /// </summary>
        /// <param name="idPedido"></param>
        /// <param name="extras"></param>
        /// <param name="platos"></param>
        /// <returns>
        /// Array ExtraPedido[] con los datos relacionados al IdPedido
        /// </returns>
        private ExtraPedido[] ObtenerExtraPedidosPorIdPedido(int idPedido, Extra[] extras, Plato[] platos)
        {
            string query = "SELECT IdPlato, IdExtra FROM ExtraPedido WHERE IdPedido = @idPedido";

            Dictionary<int, List<Extra>> platoExtrasMap = new Dictionary<int, List<Extra>>(); //matiene la relacion entre extra y plato

            try
            {
                semaforoConsulta.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@idPedido", idPedido);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) //Por cada extra crea un objeto extra y lo relaciona con un plato especifico
                            {
                                int idPlato = reader.GetInt32(0);
                                int idExtra = reader.GetInt32(1);

                                Extra extra = extras.FirstOrDefault(e => e.ID == idExtra);

                                if (extra != null)
                                {
                                    if (!platoExtrasMap.ContainsKey(idPlato))
                                    {
                                        platoExtrasMap.Add(idPlato, new List<Extra>());
                                    }
                                    platoExtrasMap[idPlato].Add(extra);
                                }
                            }
                        }
                    }
                }

                // Create ExtraPedido objects with the associated Plato and Extras.
                List<ExtraPedido> extraPedidosList = new List<ExtraPedido>();

                foreach (var kvp in platoExtrasMap)
                {
                    int idPlato = kvp.Key;
                    Plato plato = platos.FirstOrDefault(p => p.ID == idPlato);

                    if (plato != null)
                    {
                        ExtraPedido extraPedido = new ExtraPedido(idPedido, plato, kvp.Value.ToArray());
                        extraPedidosList.Add(extraPedido);
                    }
                }

                return extraPedidosList.ToArray();
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerExtraPedidosPorIdPedido(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release();
            }
        }

        /// <summary>
        /// Submetodo para ObtenerPedidos()
        /// </summary>
        /// <param name="idPedido"></param>
        /// <param name="clientes"></param>
        /// <param name="platos"></param>
        /// <param name="extras"></param>
        /// <param name="extraPedidos"></param>
        /// <returns>
        /// Objeto pedido con tos los datos del pedido
        /// </returns>
        private Pedido ObtenerPedidoPorId(int idPedido, Cliente[] clientes, Plato[] platos, Extra[] extras, ExtraPedido[] extraPedidos)
        {
            string query = "SELECT IdCliente, FechaPedido FROM Pedido WHERE IdPedido = @idPedido";

            Pedido pedido = null;

            try
            {
                semaforoConsulta.WaitOne();
                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@idPedido", idPedido);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string idCliente = reader.GetString(0);
                                Cliente cliente = clientes.FirstOrDefault(c => c.Identificacion == idCliente);
                                DateTime fechaPedido = reader.GetDateTime(1);

                                // Obtiene todos los valores IdPlato asociados con el IdPedido
                                int[] idPlatos = ObtenerIdPlatosPorIdPedido(idPedido);

                                // Obtiene los Platos en base a su IdPlato
                                List<Plato> platosList = new List<Plato>();

                                foreach (int idPlato in idPlatos)
                                {
                                    Plato plato = platos.FirstOrDefault(p => p.ID == idPlato);

                                    if (plato != null)
                                    {
                                        platosList.Add(plato);
                                    }
                                }

                                // Crea el pedido segun los datos conseguidos
                                pedido = new Pedido(idPedido, cliente, platosList.ToArray(), fechaPedido, extraPedidos);
                            }
                        }
                    }
                }
                return pedido;
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerPedidoPorId(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release();
            }
        }

        /// <summary>
        /// Submetodo para ObtenerPedidos()
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns>
        /// Array int[] con todos los IdPlato relacionados a un pedido
        /// </returns>
        private int[] ObtenerIdPlatosPorIdPedido(int idPedido)
        {
            string query = "SELECT IdPlato FROM Pedido WHERE IdPedido = @idPedido";

            List<int> idPlatosList = new List<int>();

            try
            {
                semaforoConsulta.WaitOne();
                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@idPedido", idPedido);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) //por cada IdPlato encontrado se agrega un registro con la id
                            {
                                int idPlato = reader.GetInt32(0);
                                idPlatosList.Add(idPlato);
                            }
                        }
                    }
                }
                return idPlatosList.ToArray();
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} {manager.GetString("bitacora_Lector_DBAccessError")} ObtenerIdPlatosPorIdPedido(): " + ex.Message);
                Program.bitacora.Nuevolog = true;
                return null;
            }
            finally
            {
                semaforoConsulta.Release();
            }
        }
    }
}

﻿using RestUnedClases;
using System;
using System.Data.SqlClient;
using System.Threading;

namespace RestUnedApp.DataBase.Escritura
{
    internal class EscritorBaseDatos
    {
        private static string StringConexion;
        private Semaphore semaforoEscritura;
        public EscritorBaseDatos(string Conexion, Semaphore semaforo)
        {
            StringConexion = Conexion;
            semaforoEscritura = semaforo;
        }

        /// <summary>
        /// Agrega un restaurante a la DB
        /// </summary>
        /// <param name="restaurante"></param>
        public void agregarrestaurante(Restaurante restaurante)
        {
            try
            {
                semaforoEscritura.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: AgregarRestaurante a accesado la Base de Datos");
                    Program.bitacora.Nuevolog = true;

                    string insertQuery = "INSERT INTO Restaurante (IdRestaurante, Nombre, Direccion, Estado, Telefono) " +
                                         "VALUES (@Id, @Nombre, @Direccion, @Estado, @Telefono)";

                    using (SqlCommand command = new SqlCommand(insertQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@Id", restaurante.ID);
                        command.Parameters.AddWithValue("@Nombre", restaurante.Nombre);
                        command.Parameters.AddWithValue("@Direccion", restaurante.Direccion);
                        command.Parameters.AddWithValue("@Estado", restaurante.Estado);
                        command.Parameters.AddWithValue("@Telefono", restaurante.Telefono);
                        Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Se agregó un nuevo Restaurante a la base de datos");
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Error al agregar Restaurante a la base de datos: " + ex.Message);
                Program.bitacora.Nuevolog = true;
            }
            finally
            {
                semaforoEscritura.Release();
            }
        }

        /// <summary>
        /// Agrega CategoriaPlato a la DB
        /// </summary>
        /// <param name="categoria"></param>
        public void agregarcategoriaplato(CategoriaPlato categoria)//agrega una Categoria a la DB
        {
            try
            {
                semaforoEscritura.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: AgregarCategoriaPlato a accesado la Base de Datos");
                    Program.bitacora.Nuevolog = true;

                    string insertQuery = "INSERT INTO CategoriaPlato (IdCategoria, Descripcion, Estado) " +
                                         "VALUES (@Id, @Nombre, @Categoria)";

                    using (SqlCommand command = new SqlCommand(insertQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@Id", categoria.ID);
                        command.Parameters.AddWithValue("@Nombre", categoria.Descripcion);
                        command.Parameters.AddWithValue("@Categoria", categoria.Estado);
                        Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Se agregó una nueva Categoria a la base de datos");
                        Program.bitacora.Nuevolog = true;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Error agregando Categoria a la base de datos: " + ex.Message);
                Program.bitacora.Nuevolog = true;
            }
            finally
            {
                semaforoEscritura.Release();
            }
        }

        /// <summary>
        /// Agrega Plato a la DB
        /// </summary>
        /// <param name="plato"></param>
        public void agregarplato(Plato plato)
        {
            try
            {
                semaforoEscritura.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: AgregarPlato a accesado la Base de Datos");
                    Program.bitacora.Nuevolog = true;

                    string insertQuery = "INSERT INTO Plato (IdPlato, Nombre, IdCategoria, Precio) " +
                                         "VALUES (@Id, @Nombre, @Categoria, @Precio)";

                    using (SqlCommand command = new SqlCommand(insertQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@Id", plato.ID);
                        command.Parameters.AddWithValue("@Nombre", plato.Nombre);
                        command.Parameters.AddWithValue("@Categoria", plato.Categoria.ID);
                        command.Parameters.AddWithValue("@Precio", plato.Precio);
                        Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Se agregó un nuevo Plato a la base de datos");
                        Program.bitacora.Nuevolog = true;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Error agregando Plato a la base de datos: " + ex.Message);
                Program.bitacora.Nuevolog = true;
            }
            finally
            {
                semaforoEscritura.Release();
            }
        }

        /// <summary>
        /// Agrega un Cliente a la DB
        /// </summary>
        /// <param name="cliente"></param>
        public void agregarcliente(Cliente cliente)
        {
            try
            {
                semaforoEscritura.WaitOne();
                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: AgregarCliente a accesado la Base de Datos");
                    Program.bitacora.Nuevolog = true;

                    string insertQuery = "INSERT INTO Cliente (IdCliente, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Genero) " +
                                         "VALUES (@Id, @Nombre, @A1, @A2, @FechaN, @Genero)";

                    using (SqlCommand command = new SqlCommand(insertQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@Id", cliente.Identificacion);
                        command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        command.Parameters.AddWithValue("@A1", cliente.Primer_Apellido);
                        command.Parameters.AddWithValue("@A2", cliente.Segundo_Apellido);
                        command.Parameters.AddWithValue("@FechaN", cliente.Fecha_nacimiento);
                        command.Parameters.AddWithValue("@Genero", cliente.Genero);
                        command.ExecuteNonQuery();
                        Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Se agregó un nuevo Cliente a la base de datos");
                        Program.bitacora.Nuevolog = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Error agregando cliente a la base de datos: " + ex.Message);
                Program.bitacora.Nuevolog = true;
            }
            finally
            {
                semaforoEscritura.Release();
            }
        }

        /// <summary>
        /// Agrega registro PlatoRestaurante a la DB
        /// </summary>
        /// <param name="platoRestaurante"></param>
        public void agregarplatorest(PlatoRestaurante platoRestaurante)
        {
            try
            {
                semaforoEscritura.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: AgregarPlatoRestaurante a accesado la Base de Datos");
                    Program.bitacora.Nuevolog = true;

                    foreach (Plato plato in platoRestaurante.Platos)
                    {
                        string insertPlatoRestQuery = "INSERT INTO PlatoRestaurante (IdAsignacion, IdRestaurante, IdPlato, FechaAsignacion) " +
                                                      "VALUES (@Id, @Restaurante, @Plato, @FechaAsig)";

                        using (SqlCommand command = new SqlCommand(insertPlatoRestQuery, conexion))
                        {
                            command.Parameters.AddWithValue("@Id", platoRestaurante.Id_asignacion);
                            command.Parameters.AddWithValue("@Restaurante", (object)platoRestaurante.Restaurante.ID);
                            command.Parameters.AddWithValue("@FechaAsig", platoRestaurante.Fecha_asignacion);
                            command.Parameters.AddWithValue("@Plato", plato.ID);
                            Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Se agregó una asociacion de Platos al restuarante {platoRestaurante.Restaurante.Nombre} a la base de datos");
                            Program.bitacora.Nuevolog = true;
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Error agregando PlatoRestaurante a la base de datos: " + ex.Message);
                Program.bitacora.Nuevolog = true;
            }
            finally
            {
                semaforoEscritura.Release();
            }
        }

        /// <summary>
        /// Agrega Extra a la DB
        /// </summary>
        /// <param name="ex"></param>
        public void agregarextra(Extra ex)
        {
            try
            {
                semaforoEscritura.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: AgregarExtra a accesado la Base de Datos");
                    Program.bitacora.Nuevolog = true;

                    string insertQuery = "INSERT INTO Extra (IdExtra, Descripcion, IdCategoria, Estado, Precio) " +
                                         "VALUES (@Id, @Descripcion, @Categoria, @Estado, @Precio)";

                    using (SqlCommand command = new SqlCommand(insertQuery, conexion))
                    {
                        command.Parameters.AddWithValue("@Id", ex.ID);
                        command.Parameters.AddWithValue("@Descripcion", ex.Descripcion);
                        command.Parameters.AddWithValue("@Categoria", ex.Categoria.ID);
                        command.Parameters.AddWithValue("@Estado", ex.Estado);
                        command.Parameters.AddWithValue("@Precio", ex.Precio);
                        Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Se agregó un nuevo Extra a la base de datos");
                        Program.bitacora.Nuevolog = true;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Error agregando Extra a la base de datos: " + exc.Message);
                Program.bitacora.Nuevolog = true;
            }
            finally
            {
                semaforoEscritura.Release();
            }
        }

        /// <summary>
        /// Crea una nueva IdPedido Diferente a las existentes
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        private int GenerarNuevaIdAsignacion(int[] ids)
        {
            int maxIdAsignacion = 0;

            foreach (var idUsada in ids)
            {
                if (idUsada > maxIdAsignacion)
                {
                    maxIdAsignacion = idUsada;
                }
            }

            int nuevaIdAsignacion = maxIdAsignacion + 1;

            return nuevaIdAsignacion;
        }

        /// <summary>
        /// Agrega un Pedido a la DB
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns>
        /// Boolean que indica si el agregado fue existoso
        /// </returns>
        public bool agregarPedido(Pedido pedido, int[] idsUsadas)
        {
            int idPedido = GenerarNuevaIdAsignacion(idsUsadas);
            DateTime fecha = DateTime.Now;
            string Idclente = pedido.Cliente.Identificacion;
            try
            {
                semaforoEscritura.WaitOne();

                using (SqlConnection conexion = new SqlConnection(StringConexion))
                {
                    conexion.Open();
                    Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: AgregarPedido a accesado la Base de Datos");
                    Program.bitacora.Nuevolog = true;

                    foreach (Plato plato in pedido.Plato)
                    {
                        string insertQuery = "INSERT INTO Pedido (IdPedido, IdCliente, IdPlato, FechaPedido) " +
                                         "VALUES (@Id, @Cliente, @Plato, @Fecha)";

                        using (SqlCommand command = new SqlCommand(insertQuery, conexion))
                        {
                            command.Parameters.AddWithValue("@Id", idPedido);
                            command.Parameters.AddWithValue("@Cliente", Idclente);
                            command.Parameters.AddWithValue("@Plato", plato.ID);
                            command.Parameters.AddWithValue("@Fecha", fecha);
                            Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Se agregó plato al pedido con id: {idPedido} a la base de datos");
                            Program.bitacora.Nuevolog = true;
                            command.ExecuteNonQuery();
                        }
                    }
                    foreach (ExtraPedido exp in pedido.extraPedidos)
                    {
                        if (exp != null)
                        {
                            foreach (Extra ex in exp.Extra)
                            {
                                if (ex != null)
                                {
                                    string insertQuery = "INSERT INTO ExtraPedido (IdPedido, IdPlato, IdExtra) " +
                                                         "VALUES (@Id, @Plato, @Extra)";

                                    using (SqlCommand command = new SqlCommand(insertQuery, conexion))
                                    {
                                        command.Parameters.AddWithValue("@Id", idPedido);
                                        command.Parameters.AddWithValue("@Plato", exp.Plato.ID);
                                        command.Parameters.AddWithValue("@Extra", ex.ID);
                                        Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Se agregó un extra al plato del pedido con id: {idPedido} a la base de datos");
                                        Program.bitacora.Nuevolog = true;
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception exc)
            {
                Program.bitacora.Registros.Add($"{DateTime.Now} BaseDatosSQL: Error agregando Extra a la base de datos: " + exc.Message);
                Program.bitacora.Nuevolog = true;
                return false;
            }
            finally
            {
                semaforoEscritura.Release();
            }
        }
    }
}

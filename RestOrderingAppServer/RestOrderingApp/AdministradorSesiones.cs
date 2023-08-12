using System;
using System.Collections.Generic;
using System.Threading;

namespace RestOrderingApp.Server.Sesiones
{
    public class AdministradorSesiones
    {
        private Dictionary<string, DateTime> ClientesAutenticados = new Dictionary<string, DateTime>();
        private object ClientesAutenticadosLock = new object();
        private TimeSpan DuracionSesion = TimeSpan.FromMinutes(20);
        private Timer sesionesExpiradasTimer;

        public AdministradorSesiones()
        {
            // timer que iniciar el metodo de limpieza para el diccionario de sesiones
            sesionesExpiradasTimer = new Timer(RemoverSesionesExpiradas, null, TimeSpan.Zero, TimeSpan.FromMinutes(5)); // Comprueba cada 5 minutos
        }

        /// <summary>
        /// Agrega una nueva sesion al diccionario
        /// </summary>
        /// <param name="IdSesion"></param>
        public void AgregarSesion(string IdSesion)
        {
            lock (ClientesAutenticadosLock)
            {
                ClientesAutenticados.Add(IdSesion, DateTime.Now);
                Interlocked.Increment(ref Program.usuariosautenticados); //aumenta el contador de usuarios autenticados
            }
        }

        /// <summary>
        /// Genera nuevo Id de sesion para un cliente
        /// </summary>
        /// <returns></returns>
        public string GenerarIdSesion() //Genera una id de sesion
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Cierra las sesiones por inactividad
        /// </summary>
        public void RemoverSesionesExpiradas(object state)
        {
            DateTime now = DateTime.Now;
            List<string> SesionesExpiradas = new List<string>();

            lock (ClientesAutenticadosLock)
            {
                foreach (var sesion in ClientesAutenticados)
                {
                    if ((now - sesion.Value).TotalMinutes > DuracionSesion.TotalMinutes)
                    {
                        SesionesExpiradas.Add(sesion.Key);
                    }
                }

                foreach (string sessionID in SesionesExpiradas)
                {
                    Interlocked.Decrement(ref Program.usuariosautenticados);
                    ClientesAutenticados.Remove(sessionID);
                    Program.bitacora.Registros.Add($"{DateTime.Now} Servidor: Se ha eliminado la sesión con IdSesion: {sessionID} debido a inactividad.");
                    Program.bitacora.Nuevolog = true;
                }
            }
        }

        /// <summary>
        /// Revisa si una sesion existe
        /// </summary>
        /// <param name="IdSesion"></param>
        /// <returns></returns>
        public bool Check_Sesiones(string IdSesion)
        {
            lock (ClientesAutenticadosLock)
            {
                if (!ClientesAutenticados.ContainsKey(IdSesion))
                { 
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Actualiza el temporizador de la sesion
        /// </summary>
        /// <param name="IdSesion"></param>
        public void MantenerSesion(string IdSesion)
        { 
            lock(ClientesAutenticadosLock)
            {
                ClientesAutenticados[IdSesion] = DateTime.Now;
            }
        }

        /// <summary>
        /// Elimina la sesion del diccionario
        /// </summary>
        /// <param name="IdSesion"></param>
        public void EliminarSesion(string IdSesion)
        {
            lock (ClientesAutenticados)
            {
                ClientesAutenticados.Remove(IdSesion);
                Interlocked.Decrement(ref Program.usuariosautenticados);
            }
        }
    }
}

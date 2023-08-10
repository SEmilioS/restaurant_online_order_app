using RestUnedClases;

namespace RestUnedApp.Server.Autenticacion
{
    public class Autenticador
    {
        /// <summary>
        /// Verifica la existencia de un cliente segun una id proporcionada
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public bool AutenticarCliente(string clientID)
        {
            Cliente[] clientes = Program.datosSQL.ObtenerClientes();
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Identificacion == clientID)
                {
                    return true;
                }
            }
            return false;
        }
    }


}

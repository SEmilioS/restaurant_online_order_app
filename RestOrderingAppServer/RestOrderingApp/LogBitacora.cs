using System.Collections.Generic;

namespace RestOrderingApp.Registro.Bitacora
{
    internal class LogBitacora
    {
        public List<string> Registros;
        public bool Nuevolog;

        public LogBitacora()
        {
            Registros = new List<string>();
            Nuevolog = false;
        }
    }
}

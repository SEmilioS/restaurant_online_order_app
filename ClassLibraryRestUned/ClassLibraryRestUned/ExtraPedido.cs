using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestUnedClases
{
    public class ExtraPedido
    {
        public int IdPedido;
        public Plato Plato;
        public Extra[] Extra;

        public ExtraPedido(int p, Plato pl, Extra[] ex) 
        {
            IdPedido = p;
            Plato = pl;
            Extra = ex;
        }
    }
}

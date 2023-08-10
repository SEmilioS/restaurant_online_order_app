using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestUnedClases
{
    public class Pedido
    {
        public int IdPedido;
        public Cliente Cliente;
        public Plato[] Plato;
        public DateTime FechaPedido;
        public ExtraPedido[] extraPedidos;

        public Pedido(int id, Cliente cl, Plato[] pl, DateTime FP, ExtraPedido[] exP) 
        {
            IdPedido = id;
            Cliente = cl;
            Plato = pl;
            FechaPedido = FP;
            extraPedidos = exP;
        }

    }
}

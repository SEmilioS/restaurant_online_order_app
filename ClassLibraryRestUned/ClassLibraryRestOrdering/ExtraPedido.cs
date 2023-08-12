namespace RestOrderingClases
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

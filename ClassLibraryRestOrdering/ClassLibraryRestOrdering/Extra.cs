namespace RestOrderingClases
{
    public class Extra
    {
        public int ID;
        public string Descripcion;
        public int Precio;
        public CategoriaPlato Categoria;
        public bool Estado;

        public Extra(int id, string descripcion, CategoriaPlato categoria, bool estado, int precio)
        {
            ID = id;
            Descripcion = descripcion;
            Categoria = categoria;
            Estado = estado;
            Precio = precio;
        }
    }
}

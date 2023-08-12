namespace RestOrderingClases
{
    public class Plato
    {
        public int ID;
        public string Nombre;
        public int Precio;
        public CategoriaPlato Categoria;

        public Plato(int id, string nombre, int precio, CategoriaPlato categoria)
        {
            ID = id;
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
        }
    }
}

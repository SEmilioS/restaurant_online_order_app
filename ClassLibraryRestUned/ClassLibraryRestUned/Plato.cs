using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestUnedClases
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

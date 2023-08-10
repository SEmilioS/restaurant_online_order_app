using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestUnedClases
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestUnedClases
{
    public class Restaurante
    {
        public int ID;
        public string Nombre;
        public string Direccion;
        public bool Estado;
        public string Telefono;

        public Restaurante(int id, string nombre, string direccion, bool estado, string telefono)
        {
            ID = id;
            Nombre = nombre;
            Direccion = direccion;
            Estado = estado;
            Telefono = telefono;
        }
    }
}

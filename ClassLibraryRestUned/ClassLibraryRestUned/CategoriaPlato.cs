﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestUnedClases
{
    public class CategoriaPlato
    {
        public int ID;
        public string Descripcion;
        public bool Estado;

        public CategoriaPlato(int iD, string descripcion, bool estado)
        {
            ID = iD;
            Descripcion = descripcion;
            Estado = estado;
        }
    }
}

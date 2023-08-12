using System;

namespace RestOrderingClases
{
    public class Cliente
    {
        public string Identificacion;
        public string Nombre;
        public string Primer_Apellido;
        public string Segundo_Apellido;
        public DateTime Fecha_nacimiento;
        public char Genero;

        public Cliente(string identificacion, string nombre, string primer_Apellido, string segundo_Apellido, DateTime fecha_nacimiento, char genero)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Primer_Apellido = primer_Apellido;
            Segundo_Apellido = segundo_Apellido;
            Fecha_nacimiento = fecha_nacimiento;
            Genero = genero;
        }
    }
}

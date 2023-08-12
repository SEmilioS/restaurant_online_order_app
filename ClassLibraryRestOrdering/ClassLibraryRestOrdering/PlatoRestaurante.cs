using System;

namespace RestOrderingClases
{
    public class PlatoRestaurante
    {
        public int Id_asignacion;
        public Restaurante Restaurante;
        public DateTime Fecha_asignacion;
        public Plato[] Platos = new Plato[10];

        public PlatoRestaurante(int id, Restaurante restaurante, DateTime dateTime, Plato[] platos)
        {
            Id_asignacion = id;
            Restaurante = restaurante;
            Fecha_asignacion = dateTime;
            Platos = platos;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Especialidad
    {
        public int IDEspecialidad { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        
        public ICollection<Plan> Planes { get; private set; } = new List<Plan>();

        
        public Especialidad() { }

       
        public Especialidad(string descripcion)
        {
            SetDescripcion(descripcion);
        }

        
        public Especialidad(int id, string descripcion)
        {
            IDEspecialidad = id;
            SetDescripcion(descripcion);
        }

        
        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.");

            Descripcion = descripcion.Trim();
        }

        public override string ToString()
        {
            return $"{IDEspecialidad} - {Descripcion}";
        }
    }
}

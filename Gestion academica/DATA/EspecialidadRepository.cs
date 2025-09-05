﻿using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Data
{
    public class EspecialidadRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Especialidad especialidad)
        {
            using var context = CreateContext();
            context.Especialidades.Add(especialidad);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var especialidad = context.Especialidades.Find(id);
            if (especialidad != null)
            {
                context.Especialidades.Remove(especialidad);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Especialidad? Get(int id)
        {
            using var context = CreateContext();
            return context.Especialidades.Find(id);
        }

        public IEnumerable<Especialidad> GetAll()
        {
            using var context = CreateContext();
            return context.Especialidades.ToList();
        }

        public bool Update(Especialidad especialidad)
        {
            using var context = CreateContext();
            var existingEspecialidad = context.Especialidades.Find(especialidad.IDEspecialidad);
            if (existingEspecialidad != null)
            {
                existingEspecialidad.SetDescripcion(especialidad.Descripcion);

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
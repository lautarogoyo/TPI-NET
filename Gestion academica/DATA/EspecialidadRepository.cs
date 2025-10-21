using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Domain.Model;

namespace Data
{
    public class EspecialidadRepository
    {
        private readonly string connectionString =
     "Server=(localdb)\\MSSQLLocalDB;Database=TPI;Trusted_Connection=True;";


        public IEnumerable<Especialidad> GetAll()
        {
            var lista = new List<Especialidad>();

            using var conn = new SqlConnection(connectionString);
            conn.Open();

            var query = "SELECT IDEspecialidad, Descripcion FROM Especialidades";
            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Especialidad(
                    reader.GetInt32(0),
                    reader.GetString(1)
                ));
            }

            return lista;
        }

        public Especialidad? Get(int id)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            var query = "SELECT IDEspecialidad, Descripcion FROM Especialidades WHERE IDEspecialidad = @id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Especialidad(
                    reader.GetInt32(0),
                    reader.GetString(1)
                );
            }

            return null;
        }

        public int Add(Especialidad especialidad)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            var query = "INSERT INTO Especialidades (Descripcion) OUTPUT INSERTED.IDEspecialidad VALUES (@desc)";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@desc", especialidad.Descripcion);

            int nuevoId = (int)cmd.ExecuteScalar();
            especialidad.IDEspecialidad = nuevoId;
            return nuevoId;
        }



        public bool Update(Especialidad especialidad)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            var query = "UPDATE Especialidades SET Descripcion = @desc WHERE IDEspecialidad = @id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@desc", especialidad.Descripcion);
            cmd.Parameters.AddWithValue("@id", especialidad.IDEspecialidad);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            var query = "DELETE FROM Especialidades WHERE IDEspecialidad = @id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}

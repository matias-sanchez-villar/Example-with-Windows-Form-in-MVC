using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Controler
{
    public class PersonaController
    {

        private Database database;

        // Constructor
        public PersonaController()
        {
            database = new Database();
        }

        // Guardar una nueva persona en la base de datos
        public bool GuardarPersona(Persona persona)
        {
            string query = "INSERT INTO Personas (Nombre, Edad, Direccion) VALUES (@Nombre, @Edad, @Direccion)";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", persona.Nombre),
                new SqlParameter("@Edad", persona.Edad),
                new SqlParameter("@Direccion", persona.Direccion)
            };

            try
            {
                database.ExecuteNonQuery(query, parametros);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la persona: " + ex.Message);
                return false;
            }
        }

        // Modificar los datos de una persona en la base de datos
        public bool ModificarPersona(Persona persona)
        {
            string query = "UPDATE Personas SET Nombre = @Nombre, Edad = @Edad, Direccion = @Direccion WHERE Id = @Id";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Id", persona.Id),
                new SqlParameter("@Nombre", persona.Nombre),
                new SqlParameter("@Edad", persona.Edad),
                new SqlParameter("@Direccion", persona.Direccion)
            };

            try
            {
                database.ExecuteNonQuery(query, parametros);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar la persona: " + ex.Message);
                return false;
            }
        }

        // Eliminar una persona de la base de datos
        public bool EliminarPersona(int id)
        {
            string query = "DELETE FROM Personas WHERE Id = @Id";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };

            try
            {
                database.ExecuteNonQuery(query, parametros);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la persona: " + ex.Message);
                return false;
            }
        }

        public List<Persona> ObtenerTodasLasPersonas()
        {
            string query = "SELECT * FROM Personas";
            DataTable tabla = database.Select(query);

            List<Persona> personas = new List<Persona>();

            foreach (DataRow row in tabla.Rows)
            {
                personas.Add(new Persona
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Edad = row["Edad"].ToString(),
                    Direccion = row["Direccion"].ToString()
                });
            }

            return personas;
        }
    }
}

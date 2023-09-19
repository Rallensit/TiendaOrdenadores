using Microsoft.Data.SqlClient;
using System.Data;
using WebApiOrdenadores.Models;

namespace EjercicioOrdenador.Services
{
    public class RepositorioOrdenadoresAPI : IRepositorioOrdenador
    {
        public readonly string con;

        public RepositorioOrdenadoresAPI(IConfiguration configuration)
        {
            con = configuration.GetConnectionString("TiendaOrdenadores");
        }

        public List<Ordenador>? ListaOrdenadores()
        {
            List<Ordenador> ordenadores = new();
            using (SqlConnection connection = new(con))
            {
                connection.Open();
                using (SqlCommand cmd = new("SELECT * FROM Ordenadores", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ordenador c = new Ordenador()
                            {
                                Id = reader.GetInt32(0),
                                Description = reader.GetString(1)
                            };
                            ordenadores.Add(c);
                        }
                    }
                }
                connection.Close();
            }
            return ordenadores;
        }

        public Ordenador? GetOrdenador(int id)
        {
            using (SqlConnection connection = new(con))
            {
                connection.Open();
                using (SqlCommand cmd = new("SELECT * FROM Ordenadores WHERE Id = @Id", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Ordenador c = new Ordenador()
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1)
                        };
                        connection.Close();
                        return c;
                    }
                }
            }
        }

        public void AddOrdenador(Ordenador o)
        {
            using (SqlConnection connection = new(con))
            {
                connection.Open();
                using (SqlCommand cmd = new("INSERT INTO Ordenadores VALUES (@Description)", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Description", o.Description);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Update(int id, Ordenador o)
        {
            using (SqlConnection connection = new(con))
            {
                connection.Open();
                using (SqlCommand cmd =
                       new("UPDATE Ordenadores SET Description = @Description WHERE Id = @Id", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Description", o.Description);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void DeleteOrdenador(int id)
        {
            using (SqlConnection connection = new())
            {
                connection.Open();
                using (SqlCommand cmd = new("DELETE FROM Ordenadores WHERE Id = @Id", connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}

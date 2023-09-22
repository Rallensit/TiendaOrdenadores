using System.Data;
using DotNetEnv;
using Microsoft.Data.SqlClient;
using WebApiOrdenadores.Models;

namespace WebApiOrdenadores.Services;

public class RepositorioOrdenadoresApi : IRepositorioGenerico<Ordenador>
{
    public readonly string Con;

    public RepositorioOrdenadoresApi(IConfiguration configuration)
    {
        Env.Load();
        Con = configuration.GetConnectionString(Environment.GetEnvironmentVariable("TIENDAORDENADORES02")!)!;
    }

    public List<Ordenador> Listar()
    {
        List<Ordenador> ordenadores = new();
        using SqlConnection connection = new(Con);
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
        return ordenadores;
    }

    public Ordenador Obtener(int id)
    {
        using SqlConnection connection = new(Con);
        connection.Open();
        using SqlCommand cmd = new("SELECT * FROM Ordenadores WHERE Id = @Id", connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@Id", id);
        using SqlDataReader reader = cmd.ExecuteReader();
        Ordenador c = new Ordenador()
        {
            Id = reader.GetInt32(0),
            Description = reader.GetString(1)
        };
        connection.Close();
        return c;
    }

    public void Anadir(Ordenador o)
    {
        using SqlConnection connection = new(Con);
        connection.Open();
        using (SqlCommand cmd = new("INSERT INTO Ordenadores VALUES (@Description)", connection))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Description", o.Description);
            cmd.ExecuteNonQuery();
        }
        connection.Close();
    }

    public void Actualizar(int id, Ordenador o)
    {
        using SqlConnection connection = new(Con);
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
    public void Borrar(int id)
    {
        using SqlConnection connection = new();
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
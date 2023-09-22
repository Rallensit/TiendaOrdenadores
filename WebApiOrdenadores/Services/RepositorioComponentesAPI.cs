using System.Data;
using DotNetEnv;
using Microsoft.Data.SqlClient;
using WebApiOrdenadores.Models;

namespace WebApiOrdenadores.Services;

public class RepositorioComponentesApi : IRepositorioGenerico<Componente>
{
    public readonly string Con;

    public RepositorioComponentesApi(IConfiguration configuration)
    {
        Env.Load();
        Con = configuration.GetConnectionString(Environment.GetEnvironmentVariable("TIENDAORDENADORES02")!)!;
    }

    public List<Componente> Listar()
    {
        List<Componente> componentes = new();
        using SqlConnection connection = new(Con);
        connection.Open();
        using (SqlCommand cmd = new("SELECT c.*, o.[Description] FROM Componentes AS c INNER JOIN Ordenadores AS o ON c.OrdenadorId = o.Id", connection))
        {
            cmd.CommandType = CommandType.Text;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Componente c = new Componente()
                    {
                        Id = reader.GetInt32(0),
                        Serie = reader.GetString(1),
                        Description = reader.GetString(2),
                        Calor = reader.GetInt32(3),
                        Precio = reader.GetDouble(4),
                        Cores = reader.GetInt32(5),
                        Megas = reader.GetInt64(6),
                        Tipo = (EnumTipoComponente)reader.GetInt32(7),
                        OrdenadorId = reader.GetInt32(8),
                        MiOrdenador = new()
                        {
                            Id = reader.GetInt32(8),
                            Description = reader.GetString(9)
                        }
                    };
                    componentes.Add(c);
                }
            }
        }
        connection.Close();
        return componentes;
    }

    public Componente? Obtener(int id)
    {
        using SqlConnection connection = new(Con);
        connection.Open();
        using SqlCommand cmd = new("SELECT * FROM Componentes WHERE Id = @Id", connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@Id", id);
        using SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Componente c = new Componente()
            {
                Id = reader.GetInt32(0),
                Serie = reader.GetString(1),
                Description = reader.GetString(2),
                Calor = reader.GetInt32(3),
                Precio = reader.GetDouble(4),
                Cores = reader.GetInt32(5),
                Megas = reader.GetInt64(6),
                Tipo = (EnumTipoComponente)reader.GetInt32(7),
                OrdenadorId = reader.GetInt32(8)
            };
            connection.Close();
            return c;
        }
        return null;
    }

    public void Anadir(Componente? c)
    {
        using SqlConnection connection = new(Con);
        connection.Open();
        using (SqlCommand cmd = new("INSERT INTO Componentes VALUES (@Serie, @Description, @Calor, @Precio, @Cores, @Megas, @Tipo, @OrdenadorId)", connection))
        {
            cmd.CommandType = CommandType.Text;
            if (c != null)
            {
                cmd.Parameters.AddWithValue("@Serie", c.Serie);
                cmd.Parameters.AddWithValue("@Description", c.Description);
                cmd.Parameters.AddWithValue("@Calor", c.Calor);
                cmd.Parameters.AddWithValue("@Precio", c.Precio);
                cmd.Parameters.AddWithValue("@Cores", c.Cores);
                cmd.Parameters.AddWithValue("@Megas", c.Megas);
                cmd.Parameters.AddWithValue("@Tipo", c.Tipo);
                cmd.Parameters.AddWithValue("@OrdenadorId", c.OrdenadorId);
            }

            cmd.ExecuteNonQuery();
        }
        connection.Close();
    }

    public void Actualizar(int id, Componente c)
    {
        using SqlConnection connection = new(Con);
        connection.Open();
        using (SqlCommand cmd =
               new("UPDATE Componentes SET Serie = @Serie, Description = @Description, Calor = @Calor, Precio = @Precio, Cores = @Cores, Megas = @Megas, Tipo = @Tipo, OrdenadorId = @OrdenadorId WHERE Id = @Id", connection))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Serie", c.Serie);
            cmd.Parameters.AddWithValue("@Description", c.Description);
            cmd.Parameters.AddWithValue("@Calor", c.Calor);
            cmd.Parameters.AddWithValue("@Precio", c.Precio);
            cmd.Parameters.AddWithValue("@Cores", c.Cores);
            cmd.Parameters.AddWithValue("@Megas", c.Megas);
            cmd.Parameters.AddWithValue("@Tipo", c.Tipo);
            cmd.Parameters.AddWithValue("@OrdenadorId", c.OrdenadorId);
            cmd.ExecuteNonQuery();
        }
        connection.Close();
    }
    public void Borrar(int id)
    {
        using SqlConnection connection = new();
        connection.Open();
        using (SqlCommand cmd = new("DELETE FROM Componentes WHERE Id = @Id", connection))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
        connection.Close();
    }
}
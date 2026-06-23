namespace TurnosPeluqueria_EJ06.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using TurnosPeluqueria_EJ06.Models;


public static class BD
{
    private static string _connectionString =
        @"";

    public static List<Turno> ObtenerTurnos()
    {
        List<string> turnos= new List<string>();
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"SELECT Id, NombreCliente, Servicio, FechaHora,Estado
                            FROM Turnos"
            turnos = connection.Query<string>(query).ToList();    
        }
        return turnos;
    }

    public static int AgregarTurno(Turno t)
    {
    using (SqlConnection bd = new SqlConnection(_connectionString))
    {
        string sql = @"INSERT INTO Turnos
                       (NombreCliente, Servicio, FechaHora, Estado)
                       VALUES(@NombreCliente, @Servicio, @FechaHora, @Estado)";
                 return sql;
    }
    }



    public static int CambiarEstado(int id, string nuevoEstado)
    {
      using (SqlConnection bd = new SqlConnection(_connectionString))
    {
        string sql = @"UPDATE Turnos
                       SET Estado = @Estado
                       WHERE Id = @Id";

        return bd.Execute(sql, new { Id = id, Estado = nuevoEstado });
    }
}
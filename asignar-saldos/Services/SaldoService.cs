namespace asignar_saldos.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using Models;
using System.Data.SqlClient;

public class SaldoService
{
    private readonly string _connectionString;

    public SaldoService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public List<SaldoAsignadoModels> AsignarSaldosAGestores()
    {
        var saldosAsignados = new List<SaldoAsignadoModels>();

        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                connection.Open();

                // Crear el comando para ejecutar el procedimiento almacenado
                using (var command = new SqlCommand("AsignarSaldosAGestores", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Ejecutar el procedimiento y obtener los resultados
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            saldosAsignados.Add(new SaldoAsignadoModels
                            {
                                IdGestor = reader.GetInt32(reader.GetOrdinal("id_gestor")),
                                Saldo = reader.GetDecimal(reader.GetOrdinal("saldo"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones (por ejemplo, loggear)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        return saldosAsignados;
    }
}

{
    public class SaldoService
    {

    }
}

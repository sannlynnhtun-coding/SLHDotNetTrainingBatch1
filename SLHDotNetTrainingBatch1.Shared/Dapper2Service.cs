using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SLHDotNetTrainingBatch1.Shared;

public class Dapper2Service : IDbV2Service
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public Dapper2Service(IConfiguration configuration)
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DbConnecton"));
    }

    public List<Collin> Query<Collin>(string query, object? parameters = null)
    {
        using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        var lst = connection.Query<Collin>(query, parameters).ToList();
        return lst;
    }

    public int Execute(string query, object? parameters = null)
    {
        using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        var result = connection.Execute(query, parameters);
        return result;
    }
}

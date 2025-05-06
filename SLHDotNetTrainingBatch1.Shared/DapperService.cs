using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace SLHDotNetTrainingBatch1.Shared;

public class DapperService
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public DapperService(SqlConnectionStringBuilder connectionStringBuilder)
    {
        _sqlConnectionStringBuilder = connectionStringBuilder;
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

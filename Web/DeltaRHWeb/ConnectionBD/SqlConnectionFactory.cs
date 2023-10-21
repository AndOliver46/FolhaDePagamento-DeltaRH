using System;
using System.Data;
using System.Data.SqlClient;

public class SqlConnectionFactory
{
    public SqlConnection CreateConnection()
    {
        string _connectionString = Environment.GetEnvironmentVariable("BANCO_DELTARH", EnvironmentVariableTarget.User);

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public static void CloseConnection(SqlConnection connection)
    {
        connection.Close();
    }
}
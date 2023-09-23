using System;
using System.Data;
using System.Data.SqlClient;

public class SqlConnectionFactory
{
    public SqlConnection CreateConnection()
    {
        string _connectionString = @"Data Source=DESKTOP-TJ31DK7\\SQLEXPRESS;Initial Catalog=BD_DELTA;Integrated Security=True";

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public static void CloseConnection(SqlConnection connection)
    {
        connection.Close();
    }
}
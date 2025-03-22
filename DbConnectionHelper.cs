using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

public static class DbConnectionHelper
{
    private static string connectionString = "Server=localhost; Database=ProfileLogin; Integrated Security=True; TrustServerCertificate=True;";

    public static IDbConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}

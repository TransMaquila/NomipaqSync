using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NomipaqSync
{
    static class DAL
    {

        private static string ConnectionString
        {
            get
            {
                // return @"Data Source=10.1.1.250\MSSQLLocalDb;Integrated Security=False;User ID=rgarcia;Password=Reynosa0!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                return @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=False;User ID=rgarcia;Password=Reynosa0!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
        }

        public static int Execute(string queryString)
        {
            int rowsAffected = 0;
            using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
            {
                SqlCommand commandSql = new SqlCommand();
                commandSql.Connection = connectionSql;
                commandSql.CommandText = queryString;

                try
                {
                    commandSql.Connection.Open();
                    rowsAffected = commandSql.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    Console.WriteLine(ex.Message);
                }

            }
            return rowsAffected;
        }
    }
}

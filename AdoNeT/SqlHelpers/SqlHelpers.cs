using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNeT.SqlHelpers
{
  public class SqlHelpers
        {
            private const string _connectionString = @"Server=DESKTOP-S8H9UO2\SQLEXPRESS;Database = UserDb; Trusted_Connection=true";
            public static DataTable GetDatas(string query)
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    using SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.Fill(dt);
                    con.Close();
                    return dt; ;
                };
            }
            public static int Exec(string query)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                using SqlCommand command = new SqlCommand(query, connection);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("User registered successfully!");
                }
                else
                {
                    Console.WriteLine("Registration failed!");
                }
                connection.Close();
                return rowsAffected;
            }
        }

}

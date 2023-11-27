using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdoNeT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Your_Connection_String"; 

            Console.WriteLine("Welcome!");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.Write("Choose an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterUser(connectionString);
                    break;
                case 2:
                    LoginUser(connectionString);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        static void RegisterUser(string connectionString)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            SqlHelpers.SqlHelpers.Exec($"INSERT INTO Artists VALUES (N'{username}', N'{password}')");
        }

        static void LoginUser(string connectionString)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            string selectQuery = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}' AND Password = '{password}'";
            SqlHelpers.SqlHelpers.Exec(selectQuery);
        }
    }
}

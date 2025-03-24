using System;
using MySql.Data.MySqlClient;

namespace OOP
{
    public class AdminLogin
    {
        private string server = "localhost";
        private string database = "csharpapp";
        private string username = "root";
        private string password = "";
        private string connString;

        public AdminLogin()
        {
            connString = $"Server={server};Database={database};User ID={username};Password={password};";
        }

        public string AuthenticateAdmin(string inputUsername, string inputPassword)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM Admins WHERE Username = @username AND Password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", inputUsername);
                        cmd.Parameters.AddWithValue("@password", inputPassword);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return "Authentication successful!";
                            }
                            else
                            {
                                return "Admin credentials not found. Please check your username and password.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }
    }
}

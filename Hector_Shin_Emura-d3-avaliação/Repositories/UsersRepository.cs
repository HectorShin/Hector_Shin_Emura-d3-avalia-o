using cteds_avaliacao.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cteds_avaliacao.Repositories
{
    internal class UsersRepository
    {
        private readonly string connectionString = "Server=localhost;Database=Users;Trusted_Connection=True;";
        public List<User> GetUsers()
        {
            List<User> usersList = new();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";
                conn.Open();
                SqlDataReader reader;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = new()
                        {
                            Id = reader["Id"].ToString(),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Senha = reader["Senha"].ToString()
                        };
                        usersList.Add(user);
                    }
                }
            }
            return usersList;
        }
    }
}

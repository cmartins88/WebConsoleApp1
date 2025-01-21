using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data.SqlClient;

namespace WebApplication1.Data
{
    public class User
    {
        public Guid UserID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
    }

    public class UsersData
    {
        public static IEnumerable<User> GetAll()
        {
            using (SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Trabalho1;Integrated Security=true;"))
            {
                string query = "SELECT * FROM [User]";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                IList<User> users = new List<User>();
                while(reader.Read())
                {
                    users.Add(new()
                    {
                        UserID = (Guid)reader["UserID"],
                        Email = (string)reader["Email"],
                        Password = (string)reader["Password"],
                        Name = (string)reader["Name"],
                    });
                }

                return users;
            }
        }

        public static User Get(Guid id)
        {
            using (SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;"))
            {
                string query = "SELECT * FROM User WHERE UserId = '" + id + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return new() { 
                    UserID = (Guid)reader["UserID"], 
                    Email = (string)reader["Email"], 
                    Password = (string)reader["Password"],
                    Name = (string)reader["Name"],
                };
            }
        }

        public static void Create(User user)
        {

        }

        public static void Update(User user) { }

        public static void Delete(Guid id) { }

        public static void DeleteAll() { }


    }
}

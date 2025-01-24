using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public static class UsersData
    {
        public static IEnumerable<User> GetAll()
        {
            using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
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
                        UserId = (Guid)reader["UserID"],
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
            using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
            {
                string query = "SELECT * FROM [User] WHERE UserId = @userid";
                SqlParameter paramater1 = new SqlParameter("@userid", id);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;

                cmd.Parameters.Add(paramater1);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return new() {
                    UserId = (Guid)reader["UserID"], 
                    Email = (string)reader["Email"], 
                    Password = (string)reader["Password"],
                    Name = (string)reader["Name"]
                };
            }
        }

        public static User Create(User user)
        {
            using (SqlConnection con = new SqlConnection(Utils.ConnectionString))
            {
                string query = "INSERT INTO [User] (email, password, name, vegetarian, age, country) " +
                               "VALUES (@Email, @Password, @Name, @Vegetarian, @Age, @Country)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Vegetarian", user.Vegetarian);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                cmd.Parameters.AddWithValue("@Country", user.Country);
                cmd.Parameters.AddWithValue("@Name", user.Name);

                con.Open();
                if(cmd.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Impossible to add user");
                }
            }

            return user;
        }

        public static void Update(User user) { }

        public static void Delete(Guid id) { }

        public static void DeleteAll() { }


    }
}

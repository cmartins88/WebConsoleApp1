using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class UserManager
    {
        private static readonly Dictionary<string, string> mapCountry = 
            new Dictionary<string, string> {
                { "PT", "Portugal" },
                { "Pt", "Portugal" },
                { "pt-pt", "Portugal"}
            };
        public static User createUser(User user)
        {
            mapUserCountry(user);
            return new UsersData().Create(user);
        }

        public static User mapUserCountry(User user)
        {
            if (user.Name.Contains("@"))
            {
                throw new ArgumentException("The first name cannot contain an @");
            }

            user.Country = mapCountry[user.Country];

            return user;
        }
    }
}

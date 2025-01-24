using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class RecipesData
    {
        public static IEnumerable<Recipe> GetAll() { return new[] { new Recipe() }; }

        public static Recipe Get(Guid id) { return new Recipe() { }; }
    }
}

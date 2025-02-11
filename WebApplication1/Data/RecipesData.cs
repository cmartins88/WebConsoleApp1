using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class RecipesData : IData<Recipe, Guid>
    {
        public IEnumerable<Recipe> GetAll() { return new[] { new Recipe() }; }

        public Recipe Get(Guid id) { return new Recipe() { }; }
    }
}

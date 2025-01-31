using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Recipe
    {
        public Guid RecipeId { get; set; } = new Guid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public User User { get; set; }
        public virtual IList<Comment>? Comments { get; } = default!;
    }
}

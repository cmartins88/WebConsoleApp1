namespace WebApplication1.Models
{
    // POCO entitie
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Vegetarian { get; set; }
        public string Country { get; set; } = "PT"; 
        public int Age { get; set; }
        public virtual IList<Recipe>? Recipes { get; } = default!;
    }
}
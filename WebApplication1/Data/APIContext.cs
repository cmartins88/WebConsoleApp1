using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    //DAL
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>()
                .Property<Guid>("UserId")
                .HasDefaultValueSql("NEWID()");

            mb.Entity<Recipe>()
                .Property<Guid>("RecipeId")
                .HasDefaultValueSql("NEWID()");

            mb.Entity<Comment>()
                .Property<Guid>("CommentId")
                .HasDefaultValueSql("NEWID()");
        }
    }
}

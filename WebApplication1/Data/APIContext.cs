using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    //DAL
    public class APIContext : DbContext
    {
        public APIContext() : base() { }

        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; } = default!;
        public virtual DbSet<Recipe> Recipes { get; set; } = default!;
        public virtual DbSet<Comment> Comments { get; set; } = default!;

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

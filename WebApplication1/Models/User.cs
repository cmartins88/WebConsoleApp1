using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    // POCO entities
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(8)]
        [MaxLength(12)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
        public bool Vegetarian { get; set; }

        [Required]
        [DefaultValue("PT")]
        public string? Country { get; set; }
        public int Age { get; set; }

        [NotMapped]
        public int Birth_year { get { return 0; } }

        public virtual IList<Recipe>? Recipes { get; } = default!;
        public virtual IList<Comment>? Comments { get; } = default!;

        public override bool Equals(object? obj)
        {
            return this.Email == ((User)obj).Email;
        }
    }
}
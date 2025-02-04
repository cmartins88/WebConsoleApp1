using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; } = Guid.NewGuid();
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public User? User { get; set; }
        public Recipe? Recipe { get; set; }
    }
}

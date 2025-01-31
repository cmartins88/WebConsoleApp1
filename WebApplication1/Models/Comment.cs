using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        //public User User { get; set; }
        //public Recipe Recipe { get; set; }
    }
}

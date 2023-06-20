using System.ComponentModel.DataAnnotations;

namespace TodoDemo.Api.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = string.Empty;
        public bool Complete { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

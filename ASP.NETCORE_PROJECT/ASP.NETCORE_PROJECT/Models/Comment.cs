using ASP.NETCORE_PROJECT.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCORE_PROJECT.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Please input comment !")]
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid? ProductId { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Product Product { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCORE_PROJECT.Models
{
    public class Brand
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please input brand name !")]
        public string Name { get; set; }
        public string? Image { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        [NotMapped]
        public IFormFile? BrandImage { get; set; }
    }
}

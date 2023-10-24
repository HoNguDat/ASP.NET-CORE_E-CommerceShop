using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCORE_PROJECT.Models
{
    public class TypeLaptop
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please input type name !")]
        public string Name { get; set; }
        public string? Image { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        [NotMapped]
        public IFormFile? TypeLaptopImage { get; set; }
    }
}

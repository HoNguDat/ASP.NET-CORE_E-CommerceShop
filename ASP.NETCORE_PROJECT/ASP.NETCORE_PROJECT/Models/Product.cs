using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCORE_PROJECT.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống !")]
        public string Name { get; set; }
        public string Cpu { get; set; }
        public string Feature { get; set; }
        public string Origin{ get; set; }
        public string? Face { get; set; }
        public string? Sim { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public string Screen { get; set; }
        public string? GraphicCard { get; set; }
        public string OperatingSystem { get; set; }
        public string SizeVolume { get; set; }
        public string? FrontCamera { get; set; }
        public string? BackCamera { get; set; }
        public string Battery { get; set; }
        [Required(ErrorMessage = "Please input description !")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please input quantity !")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please input year manufacturer !")]
        public int YearOfManufacturer { get; set; }
        [Required(ErrorMessage = "Please input price !")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Color !")]
        public string Color { get; set; }
        public string? Image { get; set; }
        public Guid? TypeId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? BrandId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual TypeLaptop TypeLaptop { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [NotMapped]
        public IFormFile? ProductImage { get; set; }
    }
}

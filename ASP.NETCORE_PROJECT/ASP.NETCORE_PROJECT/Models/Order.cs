using ASP.NETCORE_PROJECT.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETCORE_PROJECT.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public string? Note { get; set; }
        public double TotalBill { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

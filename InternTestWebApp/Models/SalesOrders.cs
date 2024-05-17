using System.ComponentModel.DataAnnotations;

namespace InternTestWebApp.Models
{
    public class SalesOrders
    {
        [Key]
        public int Id { set; get; }
        [Required]
        [Display(Name = "Sales Order")]
        public string SalesOrder { set; get; }
        [Required]
        [Display(Name = "Sales Order Item")]
        public string SalesOrderItem { set; get; }
        [Required]
        [Display(Name = "Work Order")]
        public string WorkOrder { set; get; }
        [Required]
        [Display(Name = "Product ID")]
        public string ProductID { set; get; }
        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescription { set; get; }
        [Required]
        [Display(Name = "Order Quantity")]
        public decimal OrderQuantity { set; get; }
        [Required]
        [Display(Name = "Order Status")]
        public string OrderStatus { set; get; }
        [Required]
        public DateTime Timestamp { set; get; }
    }
}

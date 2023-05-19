using System.ComponentModel.DataAnnotations;

namespace Cloneio.Models
{

    [Serializable]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Name length can't be more than 15.")]
        public string? Name { get; set; }
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity in stock must be greater than or equal to zero.")]
        public int AvailableStock { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public int Price { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Maximum order quantity must be greater than or equal to zero.")]
        public double MaximumOrderQuantity { get; set; }
 
    }
}

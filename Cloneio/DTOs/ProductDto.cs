using System.ComponentModel.DataAnnotations;

namespace Cloneio.DTOs
{
    public class ProductDto
    {
      
        public int ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public int AvailableStock { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public double MaximumOrderQuantity { get; set; }

        //Data Transfer Object serves the purpose to transfer data from the server to the client.
        // model Product class to fetch the data from the database and also to return that result to the client.
        //A much better practice is to have a model class to fetch the data from the database and
        //to have a DTO class to return that result to the client.

        //much better to use DTO objects because if something changes in the database the model class must change but
        //that doesn’t mean that the client wants changed results. 
    }
}

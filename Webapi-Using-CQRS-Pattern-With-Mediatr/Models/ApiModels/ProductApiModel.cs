using System.ComponentModel.DataAnnotations;

namespace Webapi_Using_CQRS_Pattern_With_Mediatr.Models.ApiModels
{
    public class ProductApiModel
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;

        public decimal Price { get; set; }
    }
}

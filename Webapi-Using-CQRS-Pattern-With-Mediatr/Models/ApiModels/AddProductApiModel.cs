namespace Webapi_Using_CQRS_Pattern_With_Mediatr.Models.ApiModels
{
    public class AddProductApiModel
    {
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public decimal Price { get; set; }
    }
}

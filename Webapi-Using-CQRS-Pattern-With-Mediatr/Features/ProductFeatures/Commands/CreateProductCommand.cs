using MediatR;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Models.ApiModels;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Models.Data.MyShopContext;

namespace Webapi_Using_CQRS_Pattern_With_Mediatr.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<bool>  //we will return product id
    {
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public decimal Price { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
        {
            private readonly MyshopContext _Context;
            public CreateProductCommandHandler(MyshopContext context)
            {
                _Context = context;
            }
            public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product product = new()
                {
                    ProductName = request.ProductName,
                    ProductDescription = request.ProductDescription,
                    Price = request.Price
                };
                await _Context.Products.AddAsync(product);
                var affectedrow = await _Context.SaveChangesAsync();
                if(affectedrow > 0)
                {
                    return true;
                }

                return false;
                
            }
        }
    }
}

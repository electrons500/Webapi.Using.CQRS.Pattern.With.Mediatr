using MediatR;
using Microsoft.EntityFrameworkCore;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Models.ApiModels;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Models.Data.MyShopContext;

namespace Webapi_Using_CQRS_Pattern_With_Mediatr.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<ProductApiModel>
    {
        public int productId { get; set; } 
        public class GetProductBtIdhandler : IRequestHandler<GetProductByIdQuery, ProductApiModel>
        {
            private readonly MyshopContext _Context;
            public GetProductBtIdhandler(MyshopContext context)
            {
                _Context = context;
            }
            public async Task<ProductApiModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                Product product = await _Context.Products.Where(p => p.ProductId == request.productId).FirstOrDefaultAsync();
                if (product is null)
                {
                    return null;
                }

                ProductApiModel model = new()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    Price = product.Price
                };

                return model;
            }
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Models.ApiModels;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Models.Data.MyShopContext;

namespace Webapi_Using_CQRS_Pattern_With_Mediatr.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductApiModel>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductApiModel>>
        {
            private readonly MyshopContext _Context;
            public GetAllProductsQueryHandler(MyshopContext context)
            {
                _Context = context;
            }
            public async Task<List<ProductApiModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                List<Product> products = await _Context.Products.ToListAsync();
                List<ProductApiModel> model = products.Select(p => new ProductApiModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    Price = p.Price
                }).ToList();
                if(products is null)
                {
                    return null;
                }

                return model;
            }
        }
    }
}

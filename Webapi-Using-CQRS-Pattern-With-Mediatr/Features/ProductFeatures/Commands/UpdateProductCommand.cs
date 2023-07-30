using MediatR;
using Microsoft.EntityFrameworkCore;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Models.Data.MyShopContext;

namespace Webapi_Using_CQRS_Pattern_With_Mediatr.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int productId { get; set; }

        public string productName { get; set; } = null!;

        public string productDescription { get; set; } = null!;

        public decimal price { get; set; }

        public class UpdateProductCommandhandler : IRequestHandler<UpdateProductCommand, bool>
        {
            private readonly MyshopContext _Context;
            public UpdateProductCommandhandler(MyshopContext context)
            {
                _Context = context;
            }
            public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product product = await _Context.Products.Where(p => p.ProductId == request.productId).FirstOrDefaultAsync();
                if (product is null)
                {
                    return false;
                }

                product.ProductId = request.productId;
                product.ProductName = request.productName;
                product.ProductDescription = request.productDescription;
                product.Price = request.price;

                 _Context.Products.Update(product);
                var affectedrow = await _Context.SaveChangesAsync();
                if (affectedrow > 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}

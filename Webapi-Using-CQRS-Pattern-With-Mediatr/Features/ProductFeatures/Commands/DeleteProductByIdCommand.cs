using MediatR;
using Microsoft.EntityFrameworkCore;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Models.Data.MyShopContext;

namespace Webapi_Using_CQRS_Pattern_With_Mediatr.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<bool>
    {
        public int productId { get; set; }
        public class DeleteProductByIdCommandhandler : IRequestHandler<DeleteProductByIdCommand, bool>
        {
            private readonly MyshopContext _Context;
            public DeleteProductByIdCommandhandler(MyshopContext context)
            {
                _Context = context;
            }
            public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                Product product = await _Context.Products.Where(p => p.ProductId == request.productId).FirstOrDefaultAsync();
                if (product is null)
                {
                    return false;
                }

                 _Context.Products.Remove(product);
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

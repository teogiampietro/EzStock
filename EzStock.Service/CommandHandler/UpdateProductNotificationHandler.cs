using EzStock.Infrastructure.Context;
using EzStock.Service.Command;
using MediatR;

namespace EzStock.Service.CommandHandler
{
    internal class UpdateProductNotificationHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private ApplicationDbContext context;

        public UpdateProductNotificationHandler(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = context.Products.FirstOrDefault(x => x.IdProduct == request.IdProduct);

            if (product is null)
            {
                return default;
            }
            else
            {
                product.Name = request.Name;
                product.Price = request.Price;
                await context.SaveChangesAsync(cancellationToken);
                return product.IdProduct;
            }
        }
    }
}

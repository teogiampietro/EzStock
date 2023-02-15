using EzStock.Infrastructure.Context;
using EzStock.Service.Products.Command;
using MediatR;

namespace EzStock.Service.Products.CommandHandler
{
    public class ProductCommandHandler : INotificationHandler<ProductCommand>
    {
        private readonly ApplicationDbContext context;

        public ProductCommandHandler(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task Handle(ProductCommand product, CancellationToken cancellationToken)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}

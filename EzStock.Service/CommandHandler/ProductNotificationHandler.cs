using EzStock.Infrastructure.Context;
using EzStock.Service.Command;
using MediatR;

namespace EzStock.Service.CommandHandler
{
    public class ProductNotificationHandler : INotificationHandler<ProductNotification>
    {
        private readonly ApplicationDbContext context;

        public ProductNotificationHandler(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task Handle(ProductNotification product, CancellationToken cancellationToken)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}

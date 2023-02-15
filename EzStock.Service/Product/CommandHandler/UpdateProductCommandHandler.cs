using EzStock.Infrastructure.Context;
using EzStock.Service.Products.Command;
using MediatR;

namespace EzStock.Service.Products.CommandHandler
{
    internal class UpdateProductCommandHandler : INotificationHandler<UpdateProductCommand>
    {
        private ApplicationDbContext context;

        public UpdateProductCommandHandler(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task Handle(UpdateProductCommand notification, CancellationToken cancellationToken)
        {
            var product = context.Products.FirstOrDefault(x => x.IdProduct == notification.IdProduct);

            if (product is null)
            {
                throw new Exception();
            }
            else
            {
                product.Name = notification.Name;
                product.Price = notification.Price;
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

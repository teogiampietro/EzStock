using EzStock.Infrastructure.Context;
using EzStock.Service.Product.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EzStock.Service.Product.CommandHandler
{
    public class DeleteProductCommandHandler : INotificationHandler<DeleteProductByIdCommand>
    {
        private readonly ApplicationDbContext context;

        public DeleteProductCommandHandler(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task Handle(DeleteProductByIdCommand notification, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.IdProduct == notification.Id, cancellationToken: cancellationToken);
            if (product is null)
                throw new Exception();

            context.Remove(product);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}

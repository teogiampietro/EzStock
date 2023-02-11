using EzStock.Infrastructure.Context;
using EzStock.Service.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EzStock.Service.CommandHandler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
    {
        private readonly ApplicationDbContext context;

        public DeleteProductCommandHandler(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.IdProduct == command.Id, cancellationToken: cancellationToken);
            if (product is null)
                return default;

            context.Remove(product);
            await context.SaveChangesAsync(cancellationToken);

            return product.IdProduct;
        }
    }
}

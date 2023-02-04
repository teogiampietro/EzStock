using EzStock.Domain.Entities;
using EzStock.Infrastructure.Context;
using EzStock.Service.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EzStock.Service.QueryHandler
{
    class GetProductByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, List<Product>>
    {
        private readonly ApplicationDbContext context;

        public GetProductByIdQueryHandler(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Product>> Handle(GetProductsByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await context.Products
                .Where(x => query.Ids.Contains(x.IdProduct))
                .ToListAsync(cancellationToken);
            return product;
        }
    }
}

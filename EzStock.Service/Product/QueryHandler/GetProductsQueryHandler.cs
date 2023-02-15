using EzStock.Domain.Entities;
using EzStock.Infrastructure.Context;
using EzStock.Service.Products.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EzStock.Service.Products.QueryHandler
{
    class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly ApplicationDbContext context;
        public GetProductsQueryHandler(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
             => await context.Products.ToListAsync(cancellationToken: cancellationToken);
    }
}

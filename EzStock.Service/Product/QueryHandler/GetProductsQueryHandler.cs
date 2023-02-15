using EzStock.Domain.Entities;
using EzStock.Infrastructure.Context;
using EzStock.Service.Product.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EzStock.Service.Product.QueryHandler
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

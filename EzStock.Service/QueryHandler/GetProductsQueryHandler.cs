using EzStock.Domain.Entities;
using EzStock.Infrastructure.Context;
using EzStock.Service.Queries;
using MediatR;

namespace EzStock.Service.QueryHandler
{
    class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly ApplicationDbContext context;
        public GetProductsQueryHandler(ApplicationDbContext _context)
        {
            context = _context; 
        }

        public Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(context.Products.ToList());
        }
    }
}

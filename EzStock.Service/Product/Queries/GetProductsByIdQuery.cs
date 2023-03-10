using EzStock.Domain.Entities;
using MediatR;

namespace EzStock.Service.Products.Queries
{
    public class GetProductsByIdQuery : IRequest<List<Product>>
    {
        public List<int> Ids { get; set; }
    }
}

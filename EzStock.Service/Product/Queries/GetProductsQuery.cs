using EzStock.Domain.Entities;
using MediatR;

namespace EzStock.Service.Product.Queries
{
    public record GetProductsQuery : IRequest<List<Product>>
    {
    }
}

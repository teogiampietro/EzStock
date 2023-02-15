using EzStock.Domain.Entities;
using MediatR;

namespace EzStock.Service.Products.Queries
{
    public record GetProductsQuery : IRequest<List<Product>>
    {
    }
}

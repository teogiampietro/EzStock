using EzStock.Domain.Entities;
using MediatR;

namespace EzStock.Service.Queries
{
    public record GetProductsQuery : IRequest<List<Product>>
    {
    }
}

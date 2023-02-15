using MediatR;

namespace EzStock.Service.Products.Command;

public record UpdateProductCommand(int IdProduct, string Name, double Price) : INotification
{
}

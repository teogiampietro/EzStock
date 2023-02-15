using MediatR;

namespace EzStock.Service.Products.Command;

public record DeleteProductByIdCommand(int Id) : INotification
{
}

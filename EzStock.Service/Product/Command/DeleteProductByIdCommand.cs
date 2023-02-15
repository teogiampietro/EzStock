using MediatR;

namespace EzStock.Service.Product.Command
{
    public record DeleteProductByIdCommand(int Id) : INotification
    {
    }
}

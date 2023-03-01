using MediatR;

namespace EzStock.Service.Auth.Command
{
    public record UserCommand(
        string UserName, 
        string Password,
        string Email) : INotification
    {
    }
}

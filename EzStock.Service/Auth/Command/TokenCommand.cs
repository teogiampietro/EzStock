using MediatR;

namespace EzStock.Service.Auth.Command
{
    public record TokenCommand(string UserName, string Password) : IRequest<string>
    {
    }
}

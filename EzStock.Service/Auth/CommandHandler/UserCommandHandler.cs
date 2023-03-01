using EzStock.Service.Auth.Command;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EzStock.Service.Auth.CommandHandler;

public class UserCommandHandler : INotificationHandler<UserCommand>
{
    private readonly UserManager<IdentityUser> _userManager;
    public UserCommandHandler(
        UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task Handle(UserCommand notification, CancellationToken cancellationToken)
    {
        var exists = await _userManager.FindByEmailAsync(notification.Email);
        if (exists != null)
            throw new Exception("User already registered.");

        var newUser = new IdentityUser(notification.UserName)
        {
            Email = notification.Email,
            EmailConfirmed = true
        };
        await _userManager.CreateAsync(newUser, notification.Password);

        var newUserHasRole = await _userManager.IsInRoleAsync(newUser, "normalUser");
        if (!newUserHasRole)
            await _userManager.AddToRoleAsync(newUser, "normalUser");
    }
}

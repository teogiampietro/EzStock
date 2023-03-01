using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EzStock.Infrastructure.Context
{
    public class SetupDataSeeder : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public SetupDataSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<IdentityDataSeeder>();

                await seeder.SeedAdminUser();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}

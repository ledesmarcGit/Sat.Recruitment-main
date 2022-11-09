using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Implementation;
using Persistence.Interfaces;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services)
        {
            services.AddScoped<IUsersFiles, UsersFiles>(x =>
            {
                return new UsersFiles(() => $"{Directory.GetCurrentDirectory()}");
            });

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersServices, UsersServices>();
        }
    }
}

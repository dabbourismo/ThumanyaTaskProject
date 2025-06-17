using Microsoft.EntityFrameworkCore;
using Thumanya.DataAccessLayer;

namespace ThumanyaCMS.ServicesExtensions
{
    public static class DatabaseServiceExtensions
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CMSDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Thumanya.DataAccessLayer")));

            return services;
        }
    }
}

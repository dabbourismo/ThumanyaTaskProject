using Thumanya.BusinessLayer.JWTService;
using Thumanya.BusinessLayer.PostBusiness;
using Thumanya.DataAccessLayer.Repository.AutherRepo;
using Thumanya.DataAccessLayer.Repository.PostRepo;

namespace ThumanyaCMS.ServicesExtensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IJwtService, JwtService>();



            return services;
        }
    }
}

using Api.Common.Mapping;

namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMappings();
            // services.AddScoped<IFirebaseService, FirebaseService>();
            // services.AddScoped<IUserService, UserService>();
            // services.AddMediatR(typeof(RegisterCommandHandler).Assembly);
            //  services.AddMediatR(typeof(UserLoginQueryHandler).Assembly);
            return services;
        }
    }
}

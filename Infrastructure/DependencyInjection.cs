// using AutoBooking.Application.Publisher;
using Application.Interfaces.IRepository.Authentication;
using Application.Interfaces.IRepository.Persistence;
using AutoBooking.Application.Users.IServices;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Infrastructure.Authentication;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    // public static class DependencyInjection
    // {
    //     public static IServiceCollection AddInfrastructure(
    //     this IServiceCollection services,
    //     ConfigurationManager configuration)
    // {
    //     services.AddScoped<IRideRepository , RideRepository>();
    //     services.AddScoped<IRabbitMQConProvider, RabbitMQConProvider>();
    //     services.AddScoped<RabbitMQRidePublisher>();


    //     return services;

    // }
    // }

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
           // services.AddScoped<IRideRepository, RideRepository>();
            services.AddAuth(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<IUserService, UserService>();

            // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            // services.AddScoped<IRabbitMQConProvider, RabbitMQConProvider>();
            // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //postgres sql connection
            //     builder.Services.AddDbContext<RideDbContext>(options =>
            //         options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            //     builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //postgres sql connection
            services.AddDbContext<AutoDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            // Add other services if needed

            return services;
        }
        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("D:\\Truenary Intern\\AutoBooking\\AutoBooking.Api\\LoginRegisterFCM.json"),
            });
            services.AddSingleton(FirebaseApp.DefaultInstance);

            return services;
        }
    }
}
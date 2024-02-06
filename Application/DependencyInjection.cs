using Application.Authentication.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            //services.AddAutoMapper(typeof(DependencyInjection).Assembly);   
          /*  services.Configure<ExceptionHandlerOptions>(options =>
            {
                options.ExceptionHandlingPath = "D:\\Truenary Intern\\AutoBooking\\AutoBooking.Application\\Response\\Error\\";
                options.AllowStatusCode404Response = true;
            });
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());
            services.AddMediatR(typeof(CheckPhoneNumberQueryHandler).Assembly);
*/
            return services;
        }
        /*public class AutoMapperConfig
        {
            public static MapperConfiguration RegisterMappings()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    // Added AutoMapper configurations here
                    cfg.CreateMap<RegisterRequest, RegisterCommand>();
                   // cfg.CreateMap<User, AuthenticateResult>();
                   // cfg.CreateMap<UserLoginRequest, User>();
                   // cfg.CreateMap<User, ServiceResult<AuthenticateResult>>();
                });

                return config;
            }
        }*/
    }
}

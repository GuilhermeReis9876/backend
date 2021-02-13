using api.Infrastructure.DtoHandler;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace api.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            services.AddScoped<IClienteService, ClienteService>();
            //Infrastructure Layer

            services.AddScoped<IClienteRepository, ClienteRepository>();


            services.AddAutoMapper(typeof(AutoMapperProfile));

        }
    }
}
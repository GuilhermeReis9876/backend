using api.Application.Services;
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
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IOperadorService, OperadorService>();
            services.AddScoped<IVeiculoService, VeiculoService>();


            //Infrastructure Layer

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IOperadorRepository, OperadorRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();

            //Infrastructure Utils
            services.AddAutoMapper(typeof(AutoMapperProfile));



        }
    }
}
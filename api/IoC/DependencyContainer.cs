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
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<ILocacaoVeiculoService, LocacaoVeiculoService>();
            services.AddScoped<IEnumService, EnumService>();


            //Infrastructure Layer

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IOperadorRepository, OperadorRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<ILocacaoVeiculoRepository, LocacaoVeiculoRepository>();


            //Infrastructure Utils
            services.AddAutoMapper(typeof(AutoMapperProfile));



        }
    }
}
using api.Application.Interfaces;
using api.Application.Services;
using api.Domain.Interfaces;
using api.Infrastructure.DtoHandler;
using api.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

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
            services.AddScoped<ICheckListService, CheckListService>();
            services.AddScoped<IUtilService, UtilService>();


            //Infrastructure Layer

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IOperadorRepository, OperadorRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<ILocacaoVeiculoRepository, LocacaoVeiculoRepository>();
            services.AddScoped<ICheckListRepository, CheckListRepository>();


            //Infrastructure Utils
            services.AddAutoMapper(typeof(AutoMapperProfile));



        }
    }
}
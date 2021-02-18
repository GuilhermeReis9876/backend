using api.Domain.Interfaces;
using api.Domain.Models;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Repositories
{
    public class LocacaoVeiculoRepository : EntityFrameworkRepository<LocacaoVeiculo>, ILocacaoVeiculoRepository
    {
        private DataContext _context;
        private readonly DbSet<LocacaoVeiculo> _locacaoVeiculo;

        public LocacaoVeiculoRepository(DataContext context) : base(context)
        {
            _context = context;
            _locacaoVeiculo = context.Set<LocacaoVeiculo>();
        }

    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Interfaces;
using api.Domain.Models;
using api.Domain.ViewModels;
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

        public async Task<IEnumerable<object>> GetReservas()
        {
            return await _context.LocacaoVeiculos
                .Where(m => m.VeiculoId == m.VeiculoId)
                .Where(m => m.Veiculo.ModeloId == m.Veiculo.ModeloId)
                .Include(m => m.Veiculo)
                .Include(m => m.Veiculo.Modelo)
                .Include(m => m.Veiculo.Modelo.Marca)
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> GetReservasByCliente(int id)
        {
            return await _context.LocacaoVeiculos
                .Where(m => m.ClienteId == id)
                .Where(m => m.VeiculoId == m.VeiculoId)
                .Where(m => m.Veiculo.ModeloId == m.Veiculo.ModeloId)
                .Include(m => m.Veiculo)
                .Include(m => m.Veiculo.Modelo)
                .Include(m => m.Veiculo.Modelo.Marca)
                .ToListAsync();
        }
    }
}

using api.Domain.Interfaces;
using api.Domain.Models;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Infrastructure.Repositories
{
    public class VeiculoRepository : EntityFrameworkRepository<Veiculo>, IVeiculoRepository
    {
        private DataContext _context;
        private readonly DbSet<Veiculo> _veiculos;

        public VeiculoRepository(DataContext context) : base(context)
        {
            _context = context;
            _veiculos = context.Set<Veiculo>();
        }

        public async override Task<Veiculo> GetById(int id)
        {
            return await _context.Veiculos
                .Where(m => m.ModeloId == m.ModeloId)
                .Where(m => m.Id == id)
                .Include(m => m.Modelo)
                .Include(m => m.Modelo.Marca)
                .FirstOrDefaultAsync();
        }

        public async override Task<IEnumerable<Veiculo>> GetAll()
        {
            return await _context.Veiculos
                .Where(m => m.ModeloId == m.ModeloId)
                .Include(m => m.Modelo)
                .Include(m => m.Modelo.Marca)
                .ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculosByCategoria(EnumTipoDeVeiculo id)
        {
            return await _context.Veiculos
                .Where(m => m.TipoDeVeiculo == id)
                .Include(m => m.Modelo)
                .Include(m => m.Modelo.Marca)
                .ToListAsync();               
        }
    }
}

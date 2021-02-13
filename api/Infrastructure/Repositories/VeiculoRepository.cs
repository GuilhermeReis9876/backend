using api.Models.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
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

    }
}

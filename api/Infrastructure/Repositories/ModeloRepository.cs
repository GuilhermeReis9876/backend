using api.Domain.Interfaces;
using api.Domain.Models;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Repositories
{
    public class ModeloRepository : EntityFrameworkRepository<Modelo>, IModeloRepository
    {
        private DataContext _context;
        private readonly DbSet<Modelo> _modelos;

        public ModeloRepository(DataContext context) : base(context)
        {
            _context = context;
            _modelos = context.Set<Modelo>();
        }

    }
}

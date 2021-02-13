using api.Models.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
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

using api.Models.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MarcaRepository : EntityFrameworkRepository<Marca>, IMarcaRepository
    {
        private DataContext _context;
        private readonly DbSet<Marca> _marcas;

        public MarcaRepository(DataContext context) : base(context)
        {
            _context = context;
            _marcas = context.Set<Marca>();
        }

    }
}

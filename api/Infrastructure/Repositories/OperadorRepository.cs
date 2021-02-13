using api.Models.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OperadorRepository : EntityFrameworkRepository<Operador>, IOperadorRepository
    {
        private DataContext _context;
        private readonly DbSet<Operador> _operadores;

        public OperadorRepository(DataContext context) : base(context)
        {
            _context = context;
            _operadores = context.Set<Operador>();
        }

    }
}

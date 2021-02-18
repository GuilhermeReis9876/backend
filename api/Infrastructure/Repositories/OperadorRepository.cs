using api.Domain.Interfaces;
using api.Domain.Models;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api.Infrastructure.Repositories
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

        public async Task<Operador> UserExists(string register)
        {
            return await _operadores.SingleOrDefaultAsync(x => x.Matricula == register);
        }

    }
}

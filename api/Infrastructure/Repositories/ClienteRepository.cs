using api.Domain.Interfaces;
using api.Domain.Models;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Infrastructure.Repositories
{
    public class ClienteRepository : EntityFrameworkRepository<Cliente>, IClienteRepository
    {
        private DataContext _context;
        private readonly DbSet<Cliente> _clientes;

        public ClienteRepository(DataContext context) : base(context)
        {
            _context = context;
            _clientes = context.Set<Cliente>();
        }

        public override async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clientes.Include(x => x.Endereco).ToListAsync();
        }

        public async Task<Cliente> UserExists(string register)
        {
            return await _clientes.SingleOrDefaultAsync(x => x.Cpf == register);
        }

    }
}

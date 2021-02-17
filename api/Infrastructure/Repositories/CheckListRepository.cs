using api.Domain.Models;
using api.Domain.Interfaces;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace api.Infrastructure.Repositories
{
    public class CheckListRepository : EntityFrameworkRepository<CheckList>, ICheckListRepository
    {
        private DataContext _context;
        private readonly DbSet<CheckList> _checkLists;

        public CheckListRepository(DataContext context) : base(context)
        {
            _context = context;
            _checkLists = context.Set<CheckList>();
        }

        public async Task<List<CheckList>> GetCheckListByLocacaoId(int id)
        {
            return await _checkLists.Where(x => x.LocacaoVeiculoId == id).ToListAsync();
        }
    }
}

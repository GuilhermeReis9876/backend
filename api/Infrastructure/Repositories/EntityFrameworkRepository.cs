using api.Models.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EntityFrameworkRepository<Entity> : IGenericRepository<Entity> where Entity : BaseModel
    {
        private readonly DataContext _entityContext;
        private readonly DbSet<Entity> _entity;

        public EntityFrameworkRepository(DataContext entityContext)
        {

            _entityContext = entityContext;
            _entity = _entityContext.Set<Entity>();
        }

        public virtual async Task<IEnumerable<Entity>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public async virtual Task Delete(Entity entity)
        {
            _entity.Remove(entity);
            await _entityContext.SaveChangesAsync();
        }

        public async virtual Task<Entity> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async virtual Task Save(Entity entity)
        {
            try
            {
                await _entity.AddAsync(entity);
                await _entityContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar no Banco de Dados: ");
            }

        }

        public async virtual Task Update(Entity entity)
        {
            _entity.Update(entity);
            await _entityContext.SaveChangesAsync();
        }
    }
}
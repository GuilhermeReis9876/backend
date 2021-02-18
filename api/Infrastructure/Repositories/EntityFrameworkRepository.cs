using api.Domain.Interfaces;
using api.Domain.Models;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Infrastructure.Repositories
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
            try
            {
                _entity.Remove(entity);
                await _entityContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message + "Não foi possível deletar: ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Não foi possível deletar: ");
            }
        }

        public async virtual Task<Entity> GetById(int id)
        {
            var entity = await _entity.FindAsync(id);
            if (entity != null)
                return entity;
            else
                throw new Exception("Não foi encontrado objeto com o Id informado!");
        }

        public async virtual Task Save(Entity entity)
        {
            try
            {
                await _entity.AddAsync(entity);
                await _entityContext.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Não foi possível salvar: ");
            }

        }

        public async virtual Task Update(Entity entity)
        {
            try
            {
                _entity.Update(entity);
                await _entityContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message + "Não foi possível atualizar: ");
            }

        }
    }
}
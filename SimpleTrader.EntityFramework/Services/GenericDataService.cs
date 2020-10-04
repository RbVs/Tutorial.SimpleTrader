using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public GenericDataService(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Get(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                return entity;
            }
        }

        public async Task<T> Create(T entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var createdEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdEntity.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }
    }
}
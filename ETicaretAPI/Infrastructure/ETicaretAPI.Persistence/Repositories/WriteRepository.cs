using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);

            return entityEntry.State == EntityState.Added;
        }


        public async Task<bool> AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public bool Delete(string id)
        {
            T Model = Table.FirstOrDefault(p => p.Id == Guid.Parse(id));
            EntityEntry<T> entityEntry = Table.Remove(Model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Delete(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);

            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

        public bool UpdateAsync(T Model)
        {
            EntityEntry<T> entityEntry = Table.Update(Model);
            return entityEntry.State == EntityState.Modified;

        }

        public bool UpdateRangeAsync(List<T> model)
        {
            Table.UpdateRange(model);
            return true;
        }
    }

}

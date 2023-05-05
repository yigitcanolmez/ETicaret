using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Product> Products{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas =  ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in datas) 
            {
                if (entity.State == EntityState.Modified)
                    entity.Entity.UpdatedDate = DateTime.UtcNow;
                
                if (entity.State == EntityState.Added)
                    entity.Entity.CreatedDate = DateTime.UtcNow;
                
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

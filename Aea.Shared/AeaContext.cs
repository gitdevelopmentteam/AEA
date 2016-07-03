using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Aea.Shared
{
    public class AeaContext: DbContext
    {
        public AeaContext()
            : base("Name=AeaContext")
        {
            
        }

        public override int SaveChanges()
        {
            var entries =
                ChangeTracker.Entries()
                    .Where(
                        x => x is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var identity = Thread.CurrentPrincipal.Identity.Name;
                var entity = entry as IAuditableEntity;
                if (entity != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = identity;
                        entity.CreatedTime = DateTime.UtcNow;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.ModifiedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.ModifiedTime).IsModified = false;
                    }
                    entity.ModifiedBy = identity;
                    entity.ModifiedTime = DateTime.UtcNow;
                }
               
            }
            return base.SaveChanges();
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}

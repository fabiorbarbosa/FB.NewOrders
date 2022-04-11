using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FB.NewOrders.Data.Context
{
    public class NewOrdersDbContext : DbContext
    {
        public NewOrdersDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NewOrdersDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                                                        .SelectMany(e => e.GetProperties())
                                                        .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(100)");
            }
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker
                                    .Entries()
                                    .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null || 
                                                    entry.Entity.GetType().GetProperty("DataAlteracao") != null))
            {
                if (entry.State == EntityState.Added && entry.Property("DataCadastro") != null)
                {
                    entry.Property("DataCadastro").CurrentValue = System.DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAlteracao").CurrentValue = System.DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
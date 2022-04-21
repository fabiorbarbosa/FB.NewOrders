using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FB.NewOrders.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FB.NewOrders.Data.Context
{
	public class NewOrdersDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Provider> Providers { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=NewOrders;User Id=sa;Password=Rep12345@!;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
				foreach (var property in modelBuilder.Model.GetEntityTypes()
						.SelectMany(e => e.GetProperties()
								.Where(p => p.ClrType == typeof(string)))) {
					property.SetColumnType("varchar(100)");
				}
				modelBuilder.ApplyConfigurationsFromAssembly(typeof(NewOrdersDbContext).Assembly);
				foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) {
					relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
				}
				base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
				foreach (var entry in ChangeTracker.Entries().Where(entry => 
																														entry.Entity.GetType().GetProperty("DateCreate") != null ||
																														entry.Entity.GetType().GetProperty("DateChange") != null))
				{
						if (entry.State == EntityState.Added)
						{
								entry.Property("DateCreate").CurrentValue = DateTime.Now;
								entry.Property("DateChange").IsModified = false;
						} else if (entry.State == EntityState.Modified)
						{
								entry.Property("DateChange").CurrentValue = DateTime.Now;
								entry.Property("DateCreate").IsModified = false;
						}
				}
				return base.SaveChangesAsync(cancellationToken);
		}
	}
}
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FB.NewOrders.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FB.NewOrders.Data.Context
{
	public class NewOrdersDbContext : DbContext
	{
		public DbSet<Produto> Produtos { get; set; }

		public NewOrdersDbContext(DbContextOptions<NewOrdersDbContext> options) : base(options)
		{
			
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
																														entry.Entity.GetType().GetProperty("DataCadastro") != null ||
																														entry.Entity.GetType().GetProperty("DataAlteracao") != null))
				{
						if (entry.State == EntityState.Added)
						{
								entry.Property("DataCadastro").CurrentValue = DateTime.Now;
								entry.Property("DataAlteracao").IsModified = false;
						} else if (entry.State == EntityState.Modified)
						{
								entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
								entry.Property("DataCadastro").IsModified = false;
						}
				}
				return base.SaveChangesAsync(cancellationToken);
		}
	}
}
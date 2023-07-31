using CustomerService.Domain;
using CustomerService.Services.Customers.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Services.Customers
{
	internal class CustomerContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CustomerConfigurations());
		}
	}
}
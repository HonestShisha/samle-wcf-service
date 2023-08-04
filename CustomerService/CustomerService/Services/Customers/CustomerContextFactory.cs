using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CustomerService.Services.Customers
{
    public class CustomerContextFactory : IDbContextFactory<CustomerContext>
    {
		private readonly DbContextOptions options;

		public CustomerContextFactory(DbContextOptions options)
		{
			this.options = options;
		}

		CustomerContext IDbContextFactory<CustomerContext>.CreateDbContext()
		{
            return new CustomerContext(options);
        }
    }
}

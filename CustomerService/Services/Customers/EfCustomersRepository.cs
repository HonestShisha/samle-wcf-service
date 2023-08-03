using CustomerService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Services.Customers
{
	internal class EfCustomersRepository : ICustomerRepository
	{
		private readonly IDbContextFactory<CustomerContext> _customerContextFactory;

		public EfCustomersRepository(IDbContextFactory<CustomerContext> customerContextFactory)
		{
			_customerContextFactory = customerContextFactory;
		}

		public void Add(Customer customer)
		{
			using var db = _customerContextFactory.CreateDbContext();
			db.Add(customer);
			db.SaveChanges();
		}

		public void Delete(Guid id)
		{
			using var db = _customerContextFactory.CreateDbContext();
			var customer = new Customer() { Id = id };
			db.Customers.Attach(customer);
			db.Customers.Remove(customer);
			db.SaveChanges();
		}

		public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
		{
			using var db = _customerContextFactory.CreateDbContext();
			return db.Customers.Where(predicate);
		}

		public Customer Get(Guid id)
		{
			using var db = _customerContextFactory.CreateDbContext();
			return db.Customers.Find(id) ?? throw new Exception($"Клиент с id = {id} не найден.");
		}

		public IEnumerable<Customer> GetAll()
		{
			using var db = _customerContextFactory.CreateDbContext();
			return db.Customers;
		}

		public void Update(Customer customer)
		{
			using var db = _customerContextFactory.CreateDbContext();
			db.Customers.Update(customer);
			db.SaveChanges();
		}
	}
}
using CustomerService.Domain;

namespace CustomerService.Services.Customers
{
	internal class CustomerService : ICustomerService
	{
		public void Add(Customer customer)
		{
			throw new NotImplementedException();
		}

		public void Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
		{
			throw new NotImplementedException();
		}

		public Customer? Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Customer> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Update(Customer customer)
		{
			throw new NotImplementedException();
		}
	}
}
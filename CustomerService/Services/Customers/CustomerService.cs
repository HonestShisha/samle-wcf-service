using CustomerService.Domain;

namespace CustomerService.Services.Customers
{
	internal class CustomerService : ICustomersService
	{
		ICustomerRepository _customers;

		public CustomerService(ICustomerRepository repository)
		{
			_customers = repository;
		}

		public void Add(Customer customer)
		{
			_customers.Add(customer);
		}

		public void Delete(Guid id)
		{
			_customers.Delete(id);
		}

		public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
		{
			return _customers.Find(predicate);
		}

		public Customer Get(Guid id)
		{
			try
			{
				return _customers.Get(id);
			} catch (Exception ex)
			{
				throw new FaultException(ex.ToString());
			}
		}

		public IEnumerable<Customer> GetAll()
		{
			return _customers.GetAll();
		}

		public void Update(Customer customer)
		{
			_customers.Update(customer);
		}
	}
}
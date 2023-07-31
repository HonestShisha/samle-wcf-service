using CustomerService.Domain;

namespace CustomerService.Services.Customers
{
	internal class InMemoryCustomerRepository : ICustomerRepository
	{
		private readonly List<Customer> _customers = new()
		{
			new Customer(){
				Id = new Guid("12345678-1234-1234-1234-123456789012"),
				Name = "John Smith",
				Description = "Loyal customer since 2010",
				Address = "123 Main St",
				City = "New York",
				Region = "NY",
				PostalCode = "10001",
				Country = "USA",
				Phone = "555-1234",
				Fax = "555-1234"
			},
			new Customer(){
				Id = new Guid("23456789-2345-2345-2345-234567890123"),
				Name = "Jane Doe",
				Description = "First-time customer",
				Address = "456 Elm St",
				City = "Los Angeles",
				Region = "CA",
				PostalCode = "90001",
				Country = "USA",
				Phone = "555-5678",
				Fax = "555-5678"
			},
			new Customer(){
				Id = new Guid("34567890-3456-3456-3456-345678901234"),
				Name = "Bob Johnson",
				Description = "Frequent buyer",
				Address = "789 Oak St",
				City = "Chicago",
				Region = "IL",
				PostalCode = "60601",
				Country = "USA",
				Phone = "555-9012",
				Fax = "555-9012"
			}
		};

		public void Add(Customer customer)
		{
			_customers.Add(customer);
		}

		public void Delete(Guid id)
		{
			var removing = _customers.FirstOrDefault(x => x.Id == id);
			if (removing != null)
			{
				_customers.Remove(removing);
			}
		}

		public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
		{
			return _customers.Where(predicate);
		}

		public Customer Get(Guid id)
		{
			return _customers.FirstOrDefault(x => x.Id == id) ?? throw new Exception($"Клиент с id = {id} не найден.");
		}

		public IEnumerable<Customer> GetAll()
		{
			return _customers;
		}

		public void Update(Customer customer)
		{
			var updating = _customers.FirstOrDefault(x => x.Id == customer.Id);
			if (updating != null)
			{
				updating.Name = customer.Name;
				updating.Description = customer.Description;
				updating.Address = customer.Address;
				updating.City = customer.City;
				updating.Region = customer.Region;
				updating.PostalCode = customer.PostalCode;
				updating.Country = customer.Country;
				updating.Phone = customer.Phone;
				updating.Fax = customer.Fax;
			}
		}
	}
}
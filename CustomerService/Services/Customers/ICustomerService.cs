using CustomerService.Domain;

namespace CustomerService.Services.Customers
{
	[ServiceContract]
	internal interface ICustomerService
	{
		[OperationContract]
		public Customer Get(Guid id);

		[OperationContract]
		public IEnumerable<Customer> GetAll();

		[OperationContract]
		public IEnumerable<Customer> Find(Func<Customer, bool> predicate);

		[OperationContract]
		public void Update(Customer customer);

		[OperationContract]
		public void Delete(Guid id);

		[OperationContract]
		public void Add(Customer customer);
	}
}
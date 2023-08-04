using CustomerService.Domain;

namespace CustomerService.Services.Customers
{
	[ServiceContract]
	public interface ICustomersService
	{
		[OperationContract]
		Customer Get(Guid id);

		[OperationContract]
		IEnumerable<Customer> GetAll();

		[OperationContract]
		void Update(Customer customer);

		[OperationContract]
		void Delete(Guid id);

		[OperationContract]
		void Add(Customer customer);
	}
}
namespace CustomerService.Services
{
	public interface IFactory<T>
	{
		T Create();
	}
}
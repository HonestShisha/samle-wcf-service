// See https://aka.ms/new-console-template for more information

//Step 1: Create an instance of the WCF proxy.
using CustomersServiceReference;

var client = new CustomersServiceClient();

Console.WriteLine("To add customer press [enter]");
Console.ReadLine();

await client.AddAsync(
	new Customer()
	{
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
	}
);

Console.WriteLine("To verify customer was added press [enter]");
Console.ReadLine();

var newlyAdded = await client.GetAsync(new Guid("12345678-1234-1234-1234-123456789012"));

Console.WriteLine("Found added customer:");

Console.WriteLine(newlyAdded.Id);
Console.WriteLine(newlyAdded.Name );
Console.WriteLine(newlyAdded.Description );
Console.WriteLine(newlyAdded.Address );
Console.WriteLine(newlyAdded.City );
Console.WriteLine(newlyAdded.Region );
Console.WriteLine(newlyAdded.PostalCode );
Console.WriteLine(newlyAdded.Country );
Console.WriteLine(newlyAdded.Phone);
Console.WriteLine(newlyAdded.Fax);

client.Close();
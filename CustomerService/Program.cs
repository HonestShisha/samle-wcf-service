using CustomerService.Services.Customers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddTransient<ICustomerRepository>(x => new InMemoryCustomerRepository());
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
builder.Services.AddDbContext<CustomerContext>(
	options => 
		options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"])
);

var app = builder.Build();

// Configure an explicit none credential type for WSHttpBinding as it defaults to Windows which requires extra configuration in ASP.NET
var myWSHttpBinding = new WSHttpBinding(SecurityMode.Transport);
myWSHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

app.UseServiceModel(builder =>
{
	Uri baseAddress = new Uri("http://localhost:8016/CustomersService/");
	builder.AddService<CustomerService.Services.Customers.CustomerService>((serviceOptions) => { })
		// Add a BasicHttpBinding at a specific endpoint
		//.AddServiceEndpoint<CustomerService.Services.Customers.CustomerService, ICustomerService>(new BasicHttpBinding(), "/CustomerService/basichttp")
		// Add a WSHttpBinding with Transport Security for TLS
		.AddServiceEndpoint<CustomerService.Services.Customers.CustomerService, ICustomersService>(myWSHttpBinding, baseAddress);
});

var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;
app.Run();

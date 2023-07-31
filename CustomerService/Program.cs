using CustomerService.Services.Customers;

var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<ICustomerRepository>(x => new InMemoryCustomerRepository());
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

// Configure an explicit none credential type for WSHttpBinding as it defaults to Windows which requires extra configuration in ASP.NET
var myWSHttpBinding = new WSHttpBinding(SecurityMode.Transport);
myWSHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

app.UseServiceModel(builder =>
{
	builder.AddService<CustomerService.Services.Customers.CustomerService>((serviceOptions) => { })
		// Add a BasicHttpBinding at a specific endpoint
		.AddServiceEndpoint<CustomerService.Services.Customers.CustomerService, ICustomerService>(new BasicHttpBinding(), "/CustomerService/basichttp")
		// Add a WSHttpBinding with Transport Security for TLS
		.AddServiceEndpoint<CustomerService.Services.Customers.CustomerService, ICustomerService>(myWSHttpBinding, "/CustomerService/WSHttps");
});

var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();

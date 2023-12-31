﻿using CustomerService.Domain;

namespace CustomerService.Services.Customers
{
	internal interface ICustomerRepository
	{
		public Customer Get(Guid id);

		public IEnumerable<Customer> GetAll();

		public void Update(Customer customer);

		public void Delete(Guid id);

		public void Add(Customer customer);
	}
}
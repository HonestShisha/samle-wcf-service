using System.Diagnostics.CodeAnalysis;

namespace CustomerService.Domain
{
	[DataContract]
	public class Customer
	{
		[DataMember]
		[AllowNull]
		public Guid Id { get; set; }

		[DataMember]
		[AllowNull]
		public string Name { get; set; }

		[DataMember]
		[AllowNull]
		public string Description { get; set; }

		[DataMember]
		[AllowNull]
		public string Address { get; set; }

		[DataMember]
		[AllowNull]
		public string City { get; set; }

		[DataMember]
		[AllowNull]
		public string Region { get; set; }

		[DataMember]
		[AllowNull]
		public string PostalCode { get; set; }

		[DataMember]
		[AllowNull]
		public string Country { get; set; }

		[DataMember]
		[AllowNull]
		public string Phone { get; set; }

		[DataMember]
		[AllowNull]
		public string Fax { get; set; }
	}
}
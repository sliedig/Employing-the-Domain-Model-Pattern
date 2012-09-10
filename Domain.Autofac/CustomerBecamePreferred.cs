using System;

namespace Domain.Autofac
{
	public class CustomerBecamePreferred : IDomainEvent
	{
		public Customer Customer { get; set; }
	}

	public class CustomerexceededAccountLimit : IDomainEvent
	{
		public Customer Customer { get; set; }
	}
}

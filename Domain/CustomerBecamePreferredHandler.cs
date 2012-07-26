using System;

namespace Domain
{
	public class CustomerBecamePreferredHandler : IHandle<CustomerBecamePreferred>
	{
		public void Handle(CustomerBecamePreferred args)
		{
			// send email to args.Customer
		}
	}
}
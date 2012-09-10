using System;

namespace Domain.Autofac
{
	public class CustomerBecamePreferredHandler : IHandle<CustomerBecamePreferred>
	{
		public void Handle(CustomerBecamePreferred args)
		{
			// send email to args.Customer
			Console.WriteLine("Called CustomerBecamePreferred");
		}
	}

	public class BillingWantsToKnowCustomerBecamePreferredHandler : IHandle<CustomerBecamePreferred>
	{
		public void Handle(CustomerBecamePreferred args)
		{
			// send email to args.Customer
			Console.WriteLine("Called BillingWantsToKnowCustomerBecamePreferredHandler");
		}
	}

	public class CustomerExceededAccountLimitHandler : IHandle<CustomerexceededAccountLimit>
	{
		public void Handle(CustomerexceededAccountLimit args)
		{
			// send email to args.Customer
			Console.WriteLine("Called CustomerExceededAccountLimitHandler");
		}
	}

	public class BillingWantsToKnowCustomerExceededAccountLimitHandler : IHandle<CustomerexceededAccountLimit>
	{
		public void Handle(CustomerexceededAccountLimit args)
		{
			// send email to args.Customer
			Console.WriteLine("Called BillingWantsToKnowCustomerExceededAccountLimitHandler");
		}
	}
}
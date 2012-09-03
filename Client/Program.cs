using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.Practices.Unity;

namespace Client
{
	class Program
	{
		static IUnityContainer _container;

		static void Main(string[] args)
		{
			_container = new UnityContainer()
						.RegisterType<IDomainEvent, CustomerBecamePreferred>()
						.RegisterType<IHandle<CustomerBecamePreferred>, CustomerBecamePreferredHandler>("CustomerBecamePreferredHandler")
						.RegisterType<IHandle<CustomerBecamePreferred>, BillingWantsToKnowCustomerBecamePreferredHandler>("BillingWantsToKnowCustomerBecamePreferredHandler")
						.RegisterType<IHandle<CustomerexceededAccountLimit>, CustomerExceededAccountLimitHandler>("CustomerExceededAccountLimitHandler")
						.RegisterType<IHandle<CustomerexceededAccountLimit>, BillingWantsToKnowCustomerExceededAccountLimitHandler>("BillingWantsToKnowCustomerExceededAccountLimitHandler");

			DomainEvents.Container = _container;

			var c = new Customer { EmailAddress = "someone@something.com", IsPreferred = false };
			Console.WriteLine("Is Preferred Customer {0}", c.IsPreferred);
			c.DoSomething();
			Console.WriteLine("Is Preferred Customer {0}", c.IsPreferred);

		}
	}
}

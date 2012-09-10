using System;
using System.Linq;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace Domain.Test
{
	[TestFixture]
	public class UnitTest
	{
		IUnityContainer _container;

		[TestFixtureSetUp]
		public void TestFixtureSetup()
		{
			_container = new UnityContainer()
						.RegisterType<IDomainEvent, CustomerBecamePreferred>()
						.RegisterType<IHandle<CustomerBecamePreferred>, CustomerBecamePreferredHandler>("CustomerBecamePreferredHandler")
						.RegisterType<IHandle<CustomerBecamePreferred>, BillingWantsToKnowCustomerBecamePreferredHandler>("BillingWantsToKnowCustomerBecamePreferredHandler")
						.RegisterType<IHandle<CustomerexceededAccountLimit>, CustomerExceededAccountLimitHandler>("CustomerExceededAccountLimitHandler")
						.RegisterType<IHandle<CustomerexceededAccountLimit>, BillingWantsToKnowCustomerExceededAccountLimitHandler>("BillingWantsToKnowCustomerExceededAccountLimitHandler");

			DomainEvents.Container = _container;

			Assert.That(_container.ResolveAll<IHandle<CustomerBecamePreferred>>().Count(), Is.EqualTo(2));
			Assert.That(_container.ResolveAll<IHandle<CustomerexceededAccountLimit>>().Count(), Is.EqualTo(2));

		}


		[Test]
		public void Do_something_should_make_customer_preferred()
		{
			var c = new Customer();
			Customer preferred = null;

			DomainEvents.Register<CustomerBecamePreferred>(p => preferred = p.Customer);

			c.DoSomething();
			Assert.That(preferred == c && c.IsPreferred);
		}
	}
}
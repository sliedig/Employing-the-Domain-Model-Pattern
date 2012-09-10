using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using NUnit.Framework;

namespace Domain.Autofac.Test
{
	public class UnitTests
	{
		[TestFixture]
		public class UnitTest
		{
			IContainer _container;

			[TestFixtureSetUp]
			public void TestFixtureSetup()
			{
				var builder = new ContainerBuilder();
				builder.RegisterAssemblyTypes(typeof(IDomainEvent).Assembly).AsClosedTypesOf(typeof(IHandle<>));
				//	builder.RegisterType<CustomerBecamePreferred>().As<IDomainEvent>();
				//	builder.RegisterType<CustomerBecamePreferredHandler>().As<IHandle<CustomerBecamePreferred>>();
				//	builder.RegisterType<BillingWantsToKnowCustomerBecamePreferredHandler>().As<IHandle<CustomerBecamePreferred>>();
				//	builder.RegisterType<CustomerExceededAccountLimitHandler>().As<IHandle<CustomerexceededAccountLimit>>();
				//	builder.RegisterType<BillingWantsToKnowCustomerExceededAccountLimitHandler>().As<IHandle<CustomerexceededAccountLimit>>();
				_container = builder.Build();

				DomainEvents.Container = _container;

				Assert.That(_container.Resolve<IEnumerable<IHandle<CustomerBecamePreferred>>>().Count(), Is.EqualTo(2));
				Assert.That(_container.Resolve<IEnumerable<IHandle<CustomerexceededAccountLimit>>>().Count(), Is.EqualTo(2));

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
}

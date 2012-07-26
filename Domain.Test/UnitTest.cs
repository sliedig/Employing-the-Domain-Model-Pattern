using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Domain.Test
{
	[TestFixture]
	public class UnitTest
	{
		[Test]
		public void DoSomethingShouldMakeCustomerPreferred()
		{
			var c = new Customer();
			Customer preferred = null;

			DomainEvents.Register<CustomerBecamePreferred>(p => preferred = p.Customer);

			c.DoSomething();
			Assert.That(preferred == c && c.IsPreferred);
		}
	}
}

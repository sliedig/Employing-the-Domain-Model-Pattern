using System;
using Autofac;
using Domain.Autofac;

namespace Client.Autofac
{
	class Program
	{
		static IContainer _container;

		static void Main(string[] args)
		{
			var builder = new ContainerBuilder();
			builder.RegisterAssemblyTypes(typeof(IDomainEvent).Assembly).AsClosedTypesOf(typeof(IHandle<>));
			_container = builder.Build();

			DomainEvents.Container = _container;

			var c = new Customer { EmailAddress = "someone@something.com", IsPreferred = false };
			Console.WriteLine("Is Preferred Customer {0}", c.IsPreferred);
			c.DoSomething();
			Console.WriteLine("Is Preferred Customer {0}", c.IsPreferred);

			Console.Read();

		}
	}
}

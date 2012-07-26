using System;

namespace Domain
{
	public interface IDomainEvent
	{
	}

	public interface IHandle<T>
	{
		void Handle(T args);
	}
}
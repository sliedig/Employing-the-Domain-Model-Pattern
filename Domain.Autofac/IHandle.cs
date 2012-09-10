using System;

namespace Domain.Autofac
{
	public interface IHandle<T>
	{
		void Handle(T args);
	}
}
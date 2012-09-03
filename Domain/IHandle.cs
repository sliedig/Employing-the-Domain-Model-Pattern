using System;

namespace Domain
{
	public interface IHandle<T>
	{
		void Handle(T args);
	}
}
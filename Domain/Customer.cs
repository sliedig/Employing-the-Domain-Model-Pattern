using System;

namespace Domain
{
	public class Customer
	{
		public bool IsPreferred { get; set; }
		protected int UnpaidOrdersAmount { get; set; }
		protected decimal Max
		{
			get { return 100M; }
		}



		public void DoSomething()
		{
			// regular logic (that also makes IsPreferred = true)
			DomainEvents.Raise(new CustomerBecamePreferred() { Customer = this });
		}

		public void SubmitOrder(OrderData data)
		{
			// call the domain model for regular order submit logic
			var customer = GetCustomer(data.CustomerId);
			var shoppingCart = GetShoppingCart(data.CartId);

			// if (customer.UnpaidOrdersAmount + shoppingCart.Total > Max)
			// {
			// 	// fail (no discussion of exceptions vs returns codes here)
			// }
			// else
			// {
			// 	customer.Purchase(shoppingCart);
			// }
			
			customer.Purchase(shoppingCart);
		}

		private ShoppingCart GetShoppingCart(int cartId)
		{
			throw new NotImplementedException();
		}

		private void Purchase(object shoppingCart)
		{
			throw new NotImplementedException();
		}

		private Customer GetCustomer(int customerId)
		{
			throw new NotImplementedException();
		}
	}

	public class ShoppingCart
	{
		public int CartId { get; set; }
		public decimal Total { get; set; }
	}

	public class OrderData
	{
		public int CustomerId { get; set; }
		public int CartId { get; set; }
	}
}

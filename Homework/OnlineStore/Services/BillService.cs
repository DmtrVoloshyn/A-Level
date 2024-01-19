using System.Text;
using Models;
using Repositories;

namespace Services
{
	public class BillService
	{
        private readonly ProductRepository _productRepository;

        public BillService()
        {
            _productRepository = new ProductRepository();
        }


        public string CreateBill(CartItem cart, User user)
		{
			string orderId = cart.CartId;
            var total = CalculateOrderTotal(cart);
            StringBuilder message = new();

            message.AppendLine($"\n\n***Dear {user.UserFirstName} {user.UserLastName} " + "thank you for your purchase!***\n");
            message.AppendLine("\tInvoice for payment.");
            message.AppendLine($"\tOrder №: {orderId} ");
            message.AppendLine($"\tDate: {cart.DateCreated}");
            message.AppendLine($"\tTotal: {total}$");

            return message.ToString();
		}

        private double CalculateOrderTotal(CartItem cart)
        {
            if (cart == null || cart.ProductIds.Length == 0)
            {
                throw new InvalidOperationException("No products in the cart.");
            }

            double totalAmount = 0;

            foreach (var productId in cart.ProductIds)
            {
                Device? selectedProduct = _productRepository.Devices.FirstOrDefault(product => product.ProductId == productId);

                if (selectedProduct != null)
                {
                    totalAmount += selectedProduct.Price;
                }
            }

            return totalAmount;
        }
    }
}

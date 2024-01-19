using Repositories;
using Models;
using SimpleCart.Repositories;

namespace Services
{
    public class CartProcessingService
    {
        private readonly ProductRepository _productRepository;
        private readonly CartRepository _cartRepository;
        private int[]? customerCart;

        public CartProcessingService(CartRepository cartRepository)
        {
            _productRepository = new ProductRepository();
            _cartRepository = cartRepository;
        }

        public void CreateCart(int[] customerSelectionProductIds, string cartId)
        {
            customerCart = customerSelectionProductIds;

            foreach (var productId in customerSelectionProductIds)
            {
                Device? selectedProduct = _productRepository.Devices.FirstOrDefault(product => product.ProductId == productId);

                if (selectedProduct != null)
                {
                    Console.WriteLine($"\nProduct added to cart: {selectedProduct.ProductName}");
                }
                else
                {
                    Console.WriteLine($"\nProduct with ID {productId} not found.");
                }
            }
            _cartRepository.AddCart(customerCart, cartId);
        }
    }
}

using Entities;
using Models;
using Repositories;
using SimpleCart.Repositories;

namespace Services
{

    public class ShopService
    {
        private readonly BillService _billService;
        private readonly UserService _userService;
        private readonly ProductRepository _productRepository;
        private readonly CartProcessingService _cartProcessingService;
        private readonly CartRepository _cartRepository;
        private static int[]? customerSelection;
        private string cartId = new Random().Next(999, 9999).ToString();

        public ShopService()
        {
            _billService = new BillService();
            _userService = new UserService();
            _productRepository = new ProductRepository();
            _cartRepository = new CartRepository();
            _cartProcessingService = new CartProcessingService(_cartRepository);
        }


        private void SelectProductsByCustomer()
        {
            List<int> customerSelections = new List<int>();
            int iterator = 0;

            do
            {
                Console.Write("Enter ProductIDs: ");
                string customerInput = Console.ReadLine();

                if (int.TryParse(customerInput, out int customerSelectionParsed))
                {
                    customerSelections.Add(customerSelectionParsed);
                    Console.Write($"\nProduct with id {customerSelectionParsed} added to cart. Continue shopping? Y/N: ");
                    iterator++;
                }

            } while (IfContinueShopping());

            customerSelection = customerSelections.ToArray();

            _cartProcessingService.CreateCart(customerSelection, cartId);
        }

        private static bool IfContinueShopping()
        {
            ConsoleKeyInfo confirmationResult;

            do
            {
                confirmationResult = Console.ReadKey();
                Console.WriteLine();
            } while (confirmationResult.Key != ConsoleKey.Y && confirmationResult.Key != ConsoleKey.N);

            return confirmationResult.Key == ConsoleKey.Y;
        }

        public void ProcessShop()
        {
            Console.WriteLine("\t*** Welcome to the Simple Shop ***\n\nSelect up to 10 products 'IDs' for adding to the cart\n");

            _productRepository.GetAvailableProducts();
            SelectProductsByCustomer();
            User newUser = _userService.CreateUser();

            CartEntity cartEntity = _cartRepository.GetCart(cartId);
            CartItem cart = new()
            {
                CartId = cartEntity.CartId,
                DateCreated = cartEntity.DateCreated,
                ProductIds = cartEntity.ProductIds
            };

            Console.WriteLine(_billService.CreateBill(cart, newUser));
            
        }
    }
}

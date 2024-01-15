using Entities;

namespace SimpleCart.Repositories
{
	public class CartRepository
	{
        private readonly CartEntity[] _mockStorage = new CartEntity[100];
        private int _mockStorageCursor = 0;

        public void AddCart(int[] productIds, string cartId)
        {
            var cart = new CartEntity()
            {
                CartId = cartId,
                DateCreated = DateTime.Now,
                ProductIds = productIds
            };

            _mockStorage[_mockStorageCursor] = cart;
            _mockStorageCursor++;
        }

        public CartEntity GetCart(string id)
        {
            foreach (var item in _mockStorage)
            {
                if (item.CartId == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}


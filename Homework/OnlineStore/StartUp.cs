using Services;

namespace SimpleCart;

public class App
{
    private readonly ShopService _shopService;

    public App(ShopService shopService)
    {
        _shopService = shopService;
    }

    public void Start()
    {
        _shopService.ProcessShop();
    }
}
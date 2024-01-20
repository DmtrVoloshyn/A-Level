using Services;

namespace SimpleCart
{
    class Program
    {
        public static void Main(string[] args)
        {
            var app = new App(new ShopService());
            app.Start();
        }
    }
}
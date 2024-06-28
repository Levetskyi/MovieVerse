using Microsoft.AspNetCore.Mvc;
using MovieVerse.Data.Cart;

namespace MovieVerse.Data.ViewComponents
{
    public class ShoppingCartSummary(ShoppingCart shoppingCart) : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart = shoppingCart;

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
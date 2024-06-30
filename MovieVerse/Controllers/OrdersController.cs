using MovieVerse.Data.ViewModels;
using MovieVerse.Data.Services;
using Microsoft.AspNetCore.Mvc;
using MovieVerse.Data.Cart;

namespace MovieVerse.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieService _moviesService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;

        public OrdersController(IMovieService movieService, ShoppingCart shoppingCart, IOrdersService ordersService) 
        { 
            _moviesService = movieService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> List()
        {
            string userId = "";
            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);

            return View(orders);
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotalPrice(),
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var movie = await _moviesService.GetMovieByIAsync(id);

            if (movie != null)
            {
                _shoppingCart.AddItemToCart(movie);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var movie = await _moviesService.GetMovieByIAsync(id);

            if (movie != null)
            {
                _shoppingCart.RemoveItemFromCart(movie);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmail = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmail);

            await _shoppingCart.ClearCartAsync();

            return View();
        }
    }
}
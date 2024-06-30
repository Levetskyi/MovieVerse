using MovieVerse.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieVerse.Data.Cart
{
    public class ShoppingCart(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = serviceProvider.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId};
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id
                && n.ShopoingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShopoingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }else
            {
                shoppingCartItem.Amount++;
            }

            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id
               && n.ShopoingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(
                n => n.ShopoingCartId == ShoppingCartId).Include(n => n.Movie).ToList());

        }

        public double GetTotalPrice()
        {
            var total = _context.ShoppingCartItems.Where(
                n => n.ShopoingCartId == ShoppingCartId).Select(n => n.Movie.Price * n.Amount).Sum();

            return total;
        }

        public async Task ClearCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(
                n => n.ShopoingCartId == ShoppingCartId).ToListAsync();

            _context.ShoppingCartItems.RemoveRange(items);

            await _context.SaveChangesAsync();
        }
    }
}

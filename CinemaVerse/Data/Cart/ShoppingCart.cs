using CinemaVerse.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaVerse.Data.Cart
{
    public class ShoppingCart(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

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
    }
}

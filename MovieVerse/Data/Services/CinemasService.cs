using MovieVerse.Data.Base;
using MovieVerse.Models;

namespace MovieVerse.Data.Services
{
    public class CinemasService(AppDbContext context) : EntityBaseRepository<Cinema>(context), ICinemasService
    {
    }
}
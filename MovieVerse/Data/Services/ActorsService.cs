using MovieVerse.Data.Base;
using MovieVerse.Models;

namespace MovieVerse.Data.Services
{
    public class ActorsService(AppDbContext context) : EntityBaseRepository<Actor>(context), IActorsService
    {

    }
}
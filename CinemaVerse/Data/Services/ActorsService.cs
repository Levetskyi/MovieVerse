using CinemaVerse.Data.Base;
using CinemaVerse.Models;

namespace CinemaVerse.Data.Services
{
    public class ActorsService(AppDbContext context) : EntityBaseRepository<Actor>(context), IActorsService
    {

    }
}
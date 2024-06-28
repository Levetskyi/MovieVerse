using MovieVerse.Data.Base;
using MovieVerse.Models;

namespace MovieVerse.Data.Services
{
    public class ProducersService(AppDbContext context) : EntityBaseRepository<Producer>(context), IProducersService
    {
    }
}
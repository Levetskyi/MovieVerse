using CinemaVerse.Data.Base;
using CinemaVerse.Models;

namespace CinemaVerse.Data.Services
{
    public class ProducersService(AppDbContext context) : EntityBaseRepository<Producer>(context), IProducersService
    {
    }
}
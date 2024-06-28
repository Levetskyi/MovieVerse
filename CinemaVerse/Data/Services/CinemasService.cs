using CinemaVerse.Data.Base;
using CinemaVerse.Models;

namespace CinemaVerse.Data.Services
{
    public class CinemasService(AppDbContext context) : EntityBaseRepository<Cinema>(context), ICinemasService
    {
    }
}
using CinemaVerse.Data.Enums;
using CinemaVerse.Models;

namespace CinemaVerse.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                     {
                         new()
                         {
                             Name = "Cinema_1",
                             Logo = "https://as2.ftcdn.net/v2/jpg/01/25/57/91/500_F_125579108_cKIL8gnBgRKqcLeyG03llZNaeFOjoCLH.jpg",
                             Description = "Description for cinema 1"
                         },
                         new()
                         {
                             Name = "Cinema_2",
                             Logo = "https://as1.ftcdn.net/v2/jpg/01/91/16/32/1000_F_191163219_0ylMaIHdahUT83L1qhI9l7eKzvJ8ZdSP.jpg",
                             Description = "Description for cinema 2"
                         },
                         new()
                         {
                             Name = "Cinema_3",
                             Logo = "https://st2.depositphotos.com/1588812/7317/v/450/depositphotos_73179751-stock-illustration-vector-logo-slate-board-for.jpg",
                             Description = "Description for cinema 3"
                         }
                     });

                    context.SaveChanges();
                }

                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                     {
                         new()
                         {
                             FullName = "Actor 1",
                             Bio = "Bio 1",
                             ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/3/3f/TechCrunch_Disrupt_2019_%2848834434641%29_%28cropped%29.jpg"
                         },
                         new()
                         {
                             FullName = "Actor 2",
                             Bio = "Bio 2",
                             ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/3/3f/TechCrunch_Disrupt_2019_%2848834434641%29_%28cropped%29.jpg"
                         },
                         new()
                         {
                             FullName = "Actor 3",
                             Bio = "Bio 3",
                             ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/3/3f/TechCrunch_Disrupt_2019_%2848834434641%29_%28cropped%29.jpg"
                         }
                     });

                    context.SaveChanges();
                }

                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                     {
                         new()
                         {
                             FullName = "Producer 1",
                             Bio = "Produser 1 Bio",
                             ProfilePictureURL = "https://res.cloudinary.com/dxw0o8aaj/image/upload/v1/explorer_profiles/unf8o6see6wip8v5fsci?pic_uid=explorer_profiles%2Funf8o6see6wip8v5fsci"
                         },
                         new()
                         {
                             FullName = "Producer 2",
                             Bio = "Produser 2 Bio",
                             ProfilePictureURL = "https://res.cloudinary.com/dxw0o8aaj/image/upload/v1/explorer_profiles/unf8o6see6wip8v5fsci?pic_uid=explorer_profiles%2Funf8o6see6wip8v5fsci"
                         },
                         new()
                         {
                             FullName = "Producer 3",
                             Bio = "Produser 3 Bio",
                             ProfilePictureURL = "https://res.cloudinary.com/dxw0o8aaj/image/upload/v1/explorer_profiles/unf8o6see6wip8v5fsci?pic_uid=explorer_profiles%2Funf8o6see6wip8v5fsci"
                         }
                     });

                    context.SaveChanges();
                }

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                     {
                         new()
                         {
                             Name = "Life",
                             Category = MovieCategory.Horror,
                             LongDescription = "This is the Life movie description",
                             PosterImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                             AgeRating = 18,
                             Country = "USA",
                             Duration = 120,
                             Language = "Polish",
                             Year = 2024,
                             StartDate = DateTime.Now.AddDays(-10),
                             EndDate = DateTime.Now.AddDays(10),
                             CinemaId = 1,
                             Price = 39.50,
                         },
                         new()
                         {
                             Name = "Life",
                             Category = MovieCategory.Horror,
                             LongDescription = "This is the Life movie description",
                             PosterImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                             AgeRating = 18,
                             Country = "USA",
                             Duration = 120,
                             Language = "Polish",
                             Year = 2024,
                             StartDate = DateTime.Now.AddDays(-10),
                             EndDate = DateTime.Now.AddDays(10),
                             CinemaId = 1,
                             Price = 39.50,
                         },
                         new()
                         {
                             Name = "Life",
                             Category = MovieCategory.Horror,
                             LongDescription = "This is the Life movie description",
                             PosterImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                             AgeRating = 18,
                             Country = "USA",
                             Duration = 120,
                             Language = "Polish",
                             Year = 2024,
                             StartDate = DateTime.Now.AddDays(-10),
                             EndDate = DateTime.Now.AddDays(10),
                             CinemaId = 1,
                             Price = 39.50,
                         },
                     });
                    context.SaveChanges();
                };

                /*if (!context.Actor_Movies.Any())
                {
                    context.Actor_Movies.AddRange(new List<Actor_Movie>()
                     {
                         new() { ActorId = 2, MovieId = 1 }
                     });

                    context.SaveChanges();
                }*/
            }
        }
    }
}
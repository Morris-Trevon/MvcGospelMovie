using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2014-10-10"),
                        Genre = "Documentary",
                        Rating ="G",
                        Price = 7.72M
                    },

                    new Movie
                    {
                        Title = "The First Vision ",
                        ReleaseDate = DateTime.Parse("1976-6-8"),
                        Genre = "Drama",
                        Rating = "G",
                        Price = 7.92M
                    },

                    new Movie
                    {
                        Title = "The Life of Jesus Christ",
                        ReleaseDate = DateTime.Parse("1992-2-23"),
                        Genre = "Historical",
                        Rating = "G",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "17 Miracles",
                        ReleaseDate = DateTime.Parse("2011-4-15"),
                        Genre = "History/Adventure",
                        Rating = "G",
                        Price = 6.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
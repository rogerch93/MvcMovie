using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System.Linq;


namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
            {
                //Look for any movies;
                if (context.Movie.Any())
                {
                    return; //DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Quando Harry Conheceu Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romance Comédia",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Caça Fantasmas",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comédia",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Caça Fantasmas 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comédia",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Ocidental",
                        Price = 3.99M
    
                    }
                 );
                context.SaveChanges();
            }
        }
    }
}

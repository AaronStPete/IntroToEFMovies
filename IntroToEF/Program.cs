using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroToEF.Data;

namespace IntroToEF
{
    class Program
    {
        static void Main(string[] args)
        {
            //query to insert movie
            var dbContext = new DataContext();

            var mov1 = new Movies
            {
                Title = "The NeverEnding Story",
                YearReleased = 1984,
                Genre = "Adventure",
                Tagline = "Boy stuck in fairytale. There's a lion-dragon.",
                Rating = 7.4m,
            };
            //dbContext.Movies.Add(mov1);

            var mov2 = new Movies
            {
                Title = "The Evil Dead",
                YearReleased = 1981,
                Genre = "Horror",
                Tagline = "Chainsaw on zombie action.",
                Rating = 7.5m,
            };
            //dbContext.Movies.Add(mov2);


            //query to update movies released in 1988 to have rating of 10
            var query1988 = dbContext.Movies.Where(x => x.YearReleased == 1988);
            foreach (var movie in query1988)
            {
                movie.Rating = 10;
            }

            //query that deletes movies titled "The Neverending Story"
            var endThisStory = dbContext.Movies.Where(x => x.Title == "The NeverEnding Story");
            //var thisMovie = dbContext.Movies.First(f => f.Title == "The NeverEnding Story");
            //dbContext.Movies.Remove(thisMovie);
            dbContext.Movies.RemoveRange(endThisStory);

            //query that finds horror movies
            var findHorror = dbContext.Movies.Where(h => h.Genre == "Horror");
            foreach (var movie in findHorror)
            {
                Console.WriteLine($"{movie.Title}");
            }

            dbContext.SaveChanges();

            Console.ReadLine();
        }
    }
}

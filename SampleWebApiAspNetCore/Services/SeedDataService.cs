using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Repositories;

namespace SampleWebApiAspNetCore.Services
{
    public class SeedDataService : ISeedDataService
    {
        public void Initialize(FoodDbContext foodcontext)
        {
            foodcontext.FoodItems.Add(new FoodEntity() { Calories = 1000, Type = "Starter", Name = "Lasagne", Created = DateTime.Now });
            foodcontext.FoodItems.Add(new FoodEntity() { Calories = 1100, Type = "Main", Name = "Hamburger", Created = DateTime.Now });
            foodcontext.FoodItems.Add(new FoodEntity() { Calories = 1200, Type = "Dessert", Name = "Spaghetti", Created = DateTime.Now });
            foodcontext.FoodItems.Add(new FoodEntity() { Calories = 1300, Type = "Starter", Name = "Pizza", Created = DateTime.Now });

            foodcontext.SaveChanges();
        }
        public void Initialize(MovieDbContext moviecontext)
        {
            moviecontext.MovieItems.Add(new MovieEntity() { Rating = 10, Genre = "Science Fiction", Name = "The Matrix", Created = DateTime.Now });
            moviecontext.MovieItems.Add(new MovieEntity() { Rating = 8, Genre = "Black Comedy", Name = "Triangle of Sadness", Created = DateTime.Now });
            moviecontext.MovieItems.Add(new MovieEntity() { Rating = 7, Genre = "Romantic/Thriller", Name = "To Catch a Thief", Created = DateTime.Now });
            moviecontext.MovieItems.Add(new MovieEntity() { Rating = 5, Genre = "Crime/Thriller", Name = "Irréversible", Created = DateTime.Now });

            moviecontext.SaveChanges();
        }
    }
}

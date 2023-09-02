using SampleWebApiAspNetCore.Repositories;

namespace SampleWebApiAspNetCore.Services
{
    public interface ISeedDataService
    {
        void Initialize(FoodDbContext foodcontext);
        void Initialize(MovieDbContext moviecontext);
    }
}

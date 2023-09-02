using SampleWebApiAspNetCore.Entities;

namespace SampleWebApiAspNetCore.Repositories
{
    public interface IMovieRepository
    {
        MovieEntity GetSingle(int id);
        void Add(MovieEntity item);
        void Delete(int id);
        MovieEntity Update(int id, MovieEntity item);
        int Count();
        bool Save();
    }
}

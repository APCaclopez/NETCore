using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Helpers;
using SampleWebApiAspNetCore.Models;
using System.Linq.Dynamic.Core;

namespace SampleWebApiAspNetCore.Repositories
{
    public class MovieSqlRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public MovieSqlRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public MovieEntity GetSingle(int id)
        {
            return _movieDbContext.MovieItems.FirstOrDefault(x => x.Id == id);
        }

        public void Add(MovieEntity item)
        {
            _movieDbContext.MovieItems.Add(item);
        }

        public void Delete(int id)
        {
            MovieEntity movieItem = GetSingle(id);
            _movieDbContext.MovieItems.Remove(movieItem);
        }

        public MovieEntity Update(int id, MovieEntity item)
        {
            _movieDbContext.MovieItems.Update(item);
            return item;
        }

        public IQueryable<MovieEntity> GetAll(QueryParameters queryParameters)
        {
            IQueryable<MovieEntity> _allItems = _movieDbContext.MovieItems.OrderBy(queryParameters.OrderBy,
              queryParameters.IsDescending());

            if (queryParameters.HasQuery())
            {
                _allItems = _allItems
                    .Where(x => x.Rating.ToString().Contains(queryParameters.Query.ToLowerInvariant())
                    || x.Name.ToLowerInvariant().Contains(queryParameters.Query.ToLowerInvariant()));
            }

            return _allItems
                .Skip(queryParameters.PageCount * (queryParameters.Page - 1))
                .Take(queryParameters.PageCount);
        }

        public int Count()
        {
            return _movieDbContext.MovieItems.Count();
        }

        public bool Save()
        {
            return (_movieDbContext.SaveChanges() >= 0);
        }
    }
}

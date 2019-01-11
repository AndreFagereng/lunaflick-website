using System.Collections.Generic;
using Model.ViewModels;

namespace DAL.Repositories
{
    public interface IMovieRepository
    {
        List<MovieListViewModel> getAllMovies();
        MovieViewModel MovieDetail(int id);
    }
}
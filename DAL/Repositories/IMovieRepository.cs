using System.Collections.Generic;
using Oblig1.ViewModels;

namespace Oblig1.DAL
{
    public interface IMovieRepository
    {
        List<MovieListViewModel> getAllMovies();
        MovieViewModel MovieDetail(int id);
    }
}
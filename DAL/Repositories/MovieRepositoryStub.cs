using Model.ViewModels;
using Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    class MovieRepositoryStub : IMovieRepository
    {
        public List<MovieListViewModel> getAllMovies()
        {

            List<MovieListViewModel> listMovieVM = new List<MovieListViewModel>();
            MovieListViewModel MLVM = new MovieListViewModel();
            MLVM.List = new List<Movie>();
            Movie tempMovie = new Movie
            {
                Title = "Gjøkeredet",
                Genre = "Drama",
                Stars = 8.7,
                Storyline = "McMurphy plasseres på et sinnssykehus hvor alle pasientene er sløvet ned av" +
                    "medikamenter og underkastet sykehusledelsen og oversøster Ratched." +
                    "McMurphy gjør opprør fra første stund og etterhvert får han de andre pasientene med seg. " +
                    "Hans opprør tas imidlertid ille opp av stedets ledelse og de ser seg derfor nødt til å knekke ham.",
                ContentRating = "15",
                ReleaseYear = "1975",
                Price = 80.00,
                Poster = "https://m.media-amazon.com/images/M/MV5BZjA0OWVhOTAtYWQxNi00YzNhLWI4ZjYtNjFjZTEyYjJlNDVlL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SY1000_CR0,0,672,1000_AL_.jpg",
                Director = "Milos Forman",
                Duration = "132 min"
            };
            MLVM.List.Add(tempMovie);
            MLVM.List.Add(tempMovie);
            MLVM.List.Add(tempMovie);
            listMovieVM.Add(MLVM);
            return listMovieVM;
        }
        public MovieViewModel MovieDetail(int id)
        {
            MovieViewModel movie = new MovieViewModel();
            Movie n = new Movie
            {
                Title = "Gjøkeredet",
                Genre = "Drama",
                Stars = 8.7,
                Storyline = "McMurphy plasseres på et sinnssykehus hvor alle pasientene er sløvet ned av" +
                    "medikamenter og underkastet sykehusledelsen og oversøster Ratched." +
                    "McMurphy gjør opprør fra første stund og etterhvert får han de andre pasientene med seg. " +
                    "Hans opprør tas imidlertid ille opp av stedets ledelse og de ser seg derfor nødt til å knekke ham.",
                ContentRating = "15",
                ReleaseYear = "1975",
                Price = 80.00,
                Poster = "https://m.media-amazon.com/images/M/MV5BZjA0OWVhOTAtYWQxNi00YzNhLWI4ZjYtNjFjZTEyYjJlNDVlL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SY1000_CR0,0,672,1000_AL_.jpg",
                Director = "Milos Forman",
                Duration = "132 min"
            };
            movie.Title = n.Title;
            return movie;
        }
}
}

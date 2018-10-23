using Oblig1.DAL;
using Oblig1.ViewModels;
using Oblig1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Oblig1.DAL
{
    public class MovieRepository
	{

        /// <summary>
        /// Denne metoden kjøres for å hente ut alle filmene i databasen på et format vi syntes
        /// var enklest å forholde oss til. Den lager en liste over alle filmer i samme sjanger,
        /// og legger disse listene i en felles stor liste. Vi kan da enkelt opprette partialviews for
        /// hver enkelt liste i denne store listen.
        ///
        /// TODO:
        /// Vi skal øke antallet filmer i databasen til neste oblig, derfor ønsker vi å endre
        /// denne metoden, slik at den dynamisk henter ut filmer som vises i Viewet, istedenfor å
        /// hente alt på en metode. For en liten database med filmer fungerer dette helt greit, men ved
        /// større øking av filmer, vil en dynamisk hentemetode være mye mer effektivt.
        /// </summary>
        /// <returns>Returnerer en liste som inneholder lister, med filmer i forskjellige sjangere.</returns>
        public List<MovieListViewModel> getAllMovies()
        {
            
            List<MovieListViewModel> listMovieVM = new List<MovieListViewModel>();
            
            using(var context = new LunaContext())
            {
                List<string> a = context.Movies.Select(m => m.Genre).Distinct().ToList();
                foreach (var genre in a)
                {
                    MovieListViewModel MLVM = new MovieListViewModel();
                    MLVM.List = new List<Movie>();
                    MLVM.listName = genre;

                    foreach(var movie in context.Movies)
                    {
                        if(movie.Genre == genre)
                        {
                            Movie tempMovie = new Movie
                            {
                                Title = movie.Title,
                                Price = movie.Price,
                                ContentRating = movie.ContentRating,
                                Duration = movie.Duration,
                                ReleaseYear = movie.ReleaseYear,
                                Stars = movie.Stars,
                                Poster = movie.Poster,
                                Storyline = movie.Storyline,
                                MovieId = movie.MovieId,
                                Director = movie.Director,
                                Genre = movie.Genre
                                
                                
                            };

                            MLVM.List.Add(tempMovie);
                        }
                    }
                    listMovieVM.Add(MLVM);
                }

            }
            return listMovieVM;
        }
        public MovieViewModel MovieDetail(int id)
        {
            MovieViewModel movie = new MovieViewModel();

            using (var context = new LunaContext())
            {
                Movie n = context.Movies.FirstOrDefault(m => m.MovieId == id);
                movie.Title = n.Title;
            };
            return movie;
        }
    }
}
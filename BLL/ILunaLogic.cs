using System.Collections.Generic;
using Model.Models;
using Model.ViewModels;

namespace BLL
{
    public interface ILunaLogic
    {
        bool AddCustomer(UserViewModel inUser);
        bool createOrder(List<Movie> movieList, string userEmail);
        List<MovieListViewModel> getAllMovies();
        UserViewModel GetDetailedUser(string userEmail);
        Movie GetMovieById(int id);
        User GetUser(string email);
        MovieViewModel MovieDetail(int id);
        List<JsMovieViewModel> OrderMovie(int orderId);
        bool UserInDB(UserViewModel user);
        List<JsOrderViewModel> UsersOrders(int userid);
    }
}
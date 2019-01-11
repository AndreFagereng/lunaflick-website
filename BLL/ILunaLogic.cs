using System.Collections.Generic;
using Model.AdminModel;
using Model.Models;
using Model.ViewModels;

namespace BLL
{
    public interface ILunaLogic
    {
       //adminstuff
        bool VerifyAdmin(Login login);
        //moviestuff
        List<JsOrderViewModel> UsersOrders(int userid);
        List<MovieListViewModel> getAllMovies();
        List<JsMovieViewModel> OrderMovie(int orderId);
        MovieViewModel MovieDetail(int id);
        List<Movie> GetMoviesById();
        Movie GetMovieById(int id);
        byte MovieAvailabilty(int id);
        bool createOrder(List<Movie> movieList, string userEmail);
        bool EditMovie(Movie movie);
        bool AddMovie(Movie movie);
        //userstuff
        UserViewModel GetDetailedUser(string userEmail);
        List<User> ListUsers();
        User GetUser(string email);
        bool AddCustomer(UserViewModel inUser);
        bool RemoveUser(string email);
        bool EditUser(User user);
        bool UserInDB(UserViewModel user);
        byte GetUserStatus(string email);
        byte SetUserStatus(string email);
        //Orderstuff
        List<Order> GetOrdersById();
        List<JsOrderLineViewModel> OrderOrderlines(int OrderLineId);
        List<OrdersAndUserViewModel> GetOrdersByDate();
        int[] GetCharInformation();
        byte SetOrderStatus(int id);



    }
}
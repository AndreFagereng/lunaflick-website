using Model.AdminModel;
using Model.Models;
using Model.ViewModels;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IAdminRepository
    {
        //Adminstuff
        bool VerifyAdmin(Login login);
  
        //Moviestuff
        List<Movie> GetMoviesById();
        byte MovieAvailabilty(int id);
        bool EditMovie(Movie movie);
        bool AddMovie(Movie movie);
        //Userstuff
        List<User> ListUsers();
        bool RemoveUser(string Email);
        bool EditUser(User user);
        byte SetUserStatus(string email);
        byte GetUserStatus(string email);
            //Orderstuff
        List<Order> GetOrdersById();
        List<JsOrderLineViewModel> OrderOrderlines(int OrdreId);
        List<OrdersAndUserViewModel> GetOrdersByDate();
        int[] GetCharInformation();
        byte SetOrderStatus(int id);

    }
}
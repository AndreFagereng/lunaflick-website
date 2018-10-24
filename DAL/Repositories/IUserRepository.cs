using System.Collections.Generic;
using Model.Models;
using Model.ViewModels;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        bool AddCustomer(UserViewModel inUser);
        bool createOrder(List<Movie> movieList, string userEmail);
        UserViewModel GetDetailedUser(string userEmail);
        User GetUser(string email);
        bool UserInDB(UserViewModel user);
    }
}
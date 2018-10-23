using System.Collections.Generic;
using Oblig1.Models;
using Oblig1.ViewModels;

namespace Oblig1.DAL
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
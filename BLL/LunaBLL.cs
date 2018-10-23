using Oblig1.DAL;
using Oblig1.Models;
using Oblig1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LunaBLL
    {
        public List<MovieListViewModel> getAllMovies()
        {
            var LunaDal = new MovieRepository();
            return LunaDal.getAllMovies();
        }

        public MovieViewModel MovieDetail(int id)
        {
            var LunaDal = new MovieRepository();
            return LunaDal.MovieDetail(id);
        }

        public List<JsOrderViewModel> UsersOrders(int userid)
        {
            var LunaDal = new OrderRepository();
            return LunaDal.UsersOrders(userid);
        }

        public List<JsMovieViewModel> OrderMovie(int orderId)
        {
            var LunaDal = new OrderRepository();
            return LunaDal.OrderMovie(orderId);
        }

        public Movie GetMovieById(int id)
        {
            var LunaDal = new OrderRepository();
            return LunaDal.GetMovieById(id);
        }

        public bool createOrder(List<Movie> movieList, string userEmail)
        {
            var LunaDal = new UserRepository();
            return LunaDal.createOrder(movieList, userEmail);
        }

        public bool AddCustomer(UserViewModel inUser)
        {
            var LunaDal = new UserRepository();
            return LunaDal.AddCustomer(inUser);
        }

        public bool UserInDB(UserViewModel user)
        {
            var LunaDal = new UserRepository();
            return LunaDal.UserInDB(user);
        }

        public UserViewModel GetDetailedUser(string userEmail)
        {
            var LunaDal = new UserRepository();
            return LunaDal.GetDetailedUser(userEmail);
        }
  
        public User GetUser(string email)
        {
            var LunaDal = new UserRepository();
            return LunaDal.GetUser(email);
        }

    }
}

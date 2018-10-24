using DAL;
using DAL.Repositories;
using Model.Models;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LunaBLL : ILunaLogic
    {
        private IMovieRepository _movieRepository;
        private IUserRepository _userRepository;
        private IOrderRepository _orderRepository;

        public LunaBLL()
        {
            _movieRepository = new MovieRepository();
            _userRepository = new UserRepository();
            _orderRepository = new OrderRepository();
        }

        public LunaBLL(IMovieRepository stub)
        {
            _movieRepository = stub;
        }

        public LunaBLL(IUserRepository stub)
        {
            _userRepository = stub;
        }

        public LunaBLL(IOrderRepository stub)
        {
            _orderRepository = stub;
        }

        public List<MovieListViewModel> getAllMovies()
        {
            return _movieRepository.getAllMovies();
        }

        public MovieViewModel MovieDetail(int id)
        {
            return _movieRepository.MovieDetail(id);
        }

        public List<JsOrderViewModel> UsersOrders(int userid)
        {
            return _orderRepository.UsersOrders(userid);
        }

        public List<JsMovieViewModel> OrderMovie(int orderId)
        {
            return _orderRepository.OrderMovie(orderId);
        }

        public Movie GetMovieById(int id)
        {
            return _orderRepository.GetMovieById(id);
        }

        public bool createOrder(List<Movie> movieList, string userEmail)
        {
            return _userRepository.createOrder(movieList, userEmail);
        }

        public bool AddCustomer(UserViewModel inUser)
        {
            return _userRepository.AddCustomer(inUser);
        }

        public bool UserInDB(UserViewModel user)
        {
            return _userRepository.UserInDB(user);
        }

        public UserViewModel GetDetailedUser(string userEmail)
        {
            return _userRepository.GetDetailedUser(userEmail);
        }

        public User GetUser(string email)
        {
            return _userRepository.GetUser(email);
        }

	}
}

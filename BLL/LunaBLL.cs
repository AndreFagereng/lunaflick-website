using DAL;
using DAL.Repositories;
using Model.AdminModel;
using Model.Models;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LunaLogic : ILunaLogic
    {
        private IMovieRepository _movieRepository;
        private IUserRepository _userRepository;
        private IOrderRepository _orderRepository;
        private IAdminRepository _adminRepository;

        public LunaLogic()
        {
            _movieRepository = new MovieRepository();
            _userRepository = new UserRepository();
            _orderRepository = new OrderRepository();
            _adminRepository = new AdminRepository();
        }

        public LunaLogic(IAdminRepository stub)
        {
            _adminRepository = stub;
        }

        public bool VerifyAdmin(Login login)
        {
            return _adminRepository.VerifyAdmin(login);
        }

        public List<User> ListUsers()
        {
            return _adminRepository.ListUsers();
        }


        /******************************************** OBLIGATORISK OPPGAVE 1 ********************************************/

        public LunaLogic(IMovieRepository stub)
        {
            _movieRepository = stub;
        }

        public LunaLogic(IUserRepository stub)
        {
            _userRepository = stub;
        }

        public LunaLogic(IOrderRepository stub)
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
        public bool RemoveUser(string email)
        {
            return _adminRepository.RemoveUser(email);
        }

        public bool EditUser(User user)
        {
            return _adminRepository.EditUser(user);
        }
        public List<Movie> GetMoviesById()
        {
            return _adminRepository.GetMoviesById();
        }

       

        public byte MovieAvailabilty(int id)
        {
            return _adminRepository.MovieAvailabilty(id);
        }
        public bool EditMovie(Movie movie)
        {
            return _adminRepository.EditMovie(movie);
        }

        public bool AddMovie(Movie movie)
        {
            return _adminRepository.AddMovie(movie);
        }
        public byte GetUserStatus(string email)
        {
            return _adminRepository.GetUserStatus(email);
        }

        public byte SetUserStatus(string email)
        {
            return _adminRepository.SetUserStatus(email);
        }
        public List<Order> GetOrdersById()
        {
            return _adminRepository.GetOrdersById();
        }
       
        public List<JsOrderLineViewModel> OrderOrderlines(int OrdreId)
        {
            return _adminRepository.OrderOrderlines(OrdreId);
        }
        public List<OrdersAndUserViewModel> GetOrdersByDate()
        {
            return _adminRepository.GetOrdersByDate();
        }
        public int[] GetCharInformation()
        {
            return _adminRepository.GetCharInformation();
        }
        public byte SetOrderStatus(int id)
        {
            return _adminRepository.SetOrderStatus(id);
        }
    }
}

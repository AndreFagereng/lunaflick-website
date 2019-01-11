using DAL.Utilities.Security;
using Model.AdminModel;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.AdminRepo;
using Model.ViewModels;

namespace DAL.Repositories.AdminRepo
{
    public class AdminRepositoryStub : IAdminRepository
    {

        public bool VerifyAdmin(Login login)
        {
            if (login.Username == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<JsOrderLineViewModel> OrderOrderlines(int OrdreLineId)
        {
            List<JsOrderLineViewModel> orderLines = new List<JsOrderLineViewModel>();
            var orderLine = new JsOrderLineViewModel()
            {
                Title = "Test",
                Price = 100
            };
            orderLines.Add(orderLine);
            orderLines.Add(orderLine);
            orderLines.Add(orderLine);
            return orderLines;
        }
        public List<User> ListUsers()
        {
            byte[] bytes = { 1, 0 };
            List<User> AllUsers = new List<User>();
            var user = new User()
            {
                UserId = 1,
                FirstName = "Test",
                LastName = "Testesen",
                Email = "testern@test.no",
                Address = "Testeveien 82",
                AccountStatus = 1,
                Password = bytes,
                Salt = bytes
            };
            AllUsers.Add(user);
            AllUsers.Add(user);
            AllUsers.Add(user);
            return AllUsers;
        }
        public bool EditUser(User user)
        {
            if (user.FirstName == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool EditMovie(Movie movie)
        {
            if (movie.Title == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool RemoveUser(string Email)
        {
            if (Email == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<Movie> GetMoviesById()
        {
            List<Movie> moviesById = new List<Movie>();
            var movie = new Movie()
            {
                MovieId = 1,
                Title = "Testfilm",
                Stars = 10.0,
                Price = 999,
                Genre = "Action",
                Director = "Tester Testing",
                ReleaseYear = "1992",
                ContentRating = "15",
                IsAvailable = 1,
                Poster = "http//:www.bilde.no",
                Duration = "132 min",
                Storyline = "Meget god film"

            };
            moviesById.Add(movie);
            moviesById.Add(movie);
            moviesById.Add(movie);
            return moviesById;
        }

        public byte MovieAvailabilty(int id)
        {

            if (id < 1)
            {

                return 0;
            }
            else
            {

                return 1;
            }

        }
        public bool AddMovie(Movie movie)
        {
            if(movie.Title == "")
            {
                return false;
            }
            return true;
        }

        public byte SetUserStatus(string email)
        {
            if(email == "")
            {
                return 0;
            }
            return 1;
        }

        public byte GetUserStatus(string email)
        {
            if (email == "")
            {
                return 0;
            }
            return 1;
        }
        public List<Order> GetOrdersById()
        {
            List<Order> orders = new List<Order>();
            Order order = new Order()
            {
                OrderId = 1,
                Status = 1
            };

            orders.Add(order);
            orders.Add(order);
            orders.Add(order);
            return orders;
        }

        public List<OrdersAndUserViewModel> GetOrdersByDate()
        {
            List<OrdersAndUserViewModel> OrdersUsers = new List<OrdersAndUserViewModel>();
            OrdersAndUserViewModel OrderUser = new OrdersAndUserViewModel
            {
                UserId = 1,
                FirstName = "Test",
                LastName = "Tester",
                OrderId = 2,
                DateTime = "28/10/2018",
                OrderCount = 3,
                Status = 0,
            };

            OrdersUsers.Add(OrderUser);
            OrdersUsers.Add(OrderUser);
            OrdersUsers.Add(OrderUser);
            return OrdersUsers;
        }

        public int[] GetCharInformation()
        {
            int[] activeCount = { 1, 2, 3, 4 };

            return activeCount;
        }

        public byte SetOrderStatus(int id)
        {
            if(id < 1)
            {
                return 0;
            }
            return 1;
        }

    }
}

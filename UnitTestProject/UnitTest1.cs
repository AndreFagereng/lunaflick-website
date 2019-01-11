using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Controllers;
using BLL;
using DAL.Repositories.AdminRepo;
using DAL.Repositories;
using System.Web.Mvc;
using System.Linq;
using MvcContrib.TestHelper;
using Model.AdminModel;
using Model.Models;
using Model.ViewModels;
using System.Web.Script.Serialization;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public AdminController setupController()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new LunaLogic(new AdminRepositoryStub()));
            SessionMock.InitializeController(controller);
            return controller;
        }


        [TestMethod]
        public void Login_NOT_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;
            //Act
            var ActionResult = (ViewResult)controller.Login();
            //Assert
            Assert.AreEqual(ActionResult.ViewName, "");
        }
        [TestMethod]
        public void Login_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;
            //Act
            var result = (RedirectToRouteResult)controller.Login();
            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "AdminPanel");
        }
        [TestMethod]
        public void Login_OK_POST()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;
            var loginAdmin = new Model.AdminModel.Login()
            {
                Username = "admin",
                Password = "admin"
            };
            //Act
            var resultat = (RedirectToRouteResult)controller.Login(loginAdmin);
            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "AdminPanel");
        }
        [TestMethod]
        public void Login_FAIL_POST()
        {
            //Arrange
            var controller = new AdminController(new LunaLogic(new AdminRepositoryStub()));
            // Feil brukernavn og passord
            var loginAdmin = new Model.AdminModel.Login()
            {
                Username = "notadmin",
                Password = "notadmin"
            };
            controller.ViewData.ModelState.AddModelError("Password", "Feil brukernavn eller passord");
            var resultat = (ViewResult)controller.Login(loginAdmin);
            Assert.IsTrue(resultat.ViewData.ModelState.Count == 1);
            Assert.AreEqual(resultat.ViewName, "");
        }
        [TestMethod]
        public void Login_FAIL_INPUT()
        {
            //Arrange
            var controller = new AdminController(new LunaLogic(new AdminRepositoryStub()));
            // Feil brukernavn og passord
            var loginAdmin = new Model.AdminModel.Login();
            controller.ViewData.ModelState.AddModelError("Password", "Feil brukernavn eller passord");
            //Act
            var resultat = (ViewResult)controller.Login(loginAdmin);
            //Assert
            Assert.IsTrue(resultat.ViewData.ModelState.Count == 1);
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void Logout_OK()
        {
            // Arrange
            var controller = setupController();
            controller.Session["adminSession"] = "ikkeNull";

            // Act

            var resultat = (RedirectToRouteResult)controller.Logout();

            // Assert

            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Login");
        }

        [TestMethod]
        public void AdminPanel_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;
            //Act
            var result = (ViewResult)controller.AdminPanel();
            //Assert
            Assert.AreEqual(result.ViewName, "");
        }
        [TestMethod]
        public void AdminPanel_NOT_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;
            //Act
            var result = (RedirectToRouteResult)controller.AdminPanel();
            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Login");
        }

        [TestMethod]
        public void SetOrderStatus_OK()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;

            int id = 1;
            
            //Act

            var resultat = (RedirectToRouteResult)controller.SetOrderStatus(id);

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "EditOrders");


        }
        [TestMethod]
        public void SetOrderStatus_FAILED()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;

            int id = 1;

            //Act

            var resultat = (RedirectToRouteResult)controller.SetOrderStatus(id);

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Login");
        }

        [TestMethod]
        public void UserOrder_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;
            //Act
            var result = (ViewResult)controller.UserOrders();
            //Assert
            Assert.AreEqual(result.ViewName, "");
        }
        [TestMethod]
        public void UserOrder_NOT_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;
            //Act
            var result = (RedirectToRouteResult)controller.UserOrders();
            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Login");
        }

        [TestMethod]
        public void EditUsers_OK()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;

            List<User> users = new List<User>();
            User user = new User()
            {
                UserId = 1,
                FirstName = "Test",
                LastName = "Testesen",
                Email = "testern@test.no",
                Address = "Testeveien 82",
                AccountStatus = 1
            };
            users.Add(user);
            users.Add(user);
            users.Add(user);

            //Act 

            var resultat = (ViewResult)controller.EditUsers();
            var resultatliste = (List<User>)resultat.Model;

            //Assert

            Assert.AreEqual(resultat.ViewName, "");

            for(var i = 0; i < resultatliste.Count; i++)
            {
                Assert.AreEqual(users[i].UserId, resultatliste[i].UserId);
                Assert.AreEqual(users[i].Email, resultatliste[i].Email);
                Assert.AreEqual(users[i].FirstName, resultatliste[i].FirstName);
                Assert.AreEqual(users[i].LastName, resultatliste[i].LastName);
                Assert.AreEqual(users[i].AccountStatus, resultatliste[i].AccountStatus);
                Assert.AreEqual(users[i].Address, resultatliste[i].Address);
            }

        }
        [TestMethod]
        public void EditUsers_FAILED()
        {
            var controller = setupController();
            controller.Session["adminSession"] = false;

            //Act

            var resultat = (RedirectToRouteResult)controller.EditUsers();

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Login");
        }

        [TestMethod]
        public void DetailedEditUsers_stringPara_LOGGED_IN()
        {
            //Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new LunaLogic(new UserRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["adminSession"] = true;
            var expectedUser = new User()
            {
                Email = "minEpost",
                FirstName = "Per",
                LastName = "Hansen",
            };
            //Act
            var result = (ViewResult)controller.DetailedEditUsers(expectedUser.Email);
            var result2 = (User)result.Model;
            //Assert
            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(expectedUser.Email, result2.Email);
            Assert.AreEqual(expectedUser.FirstName, result2.FirstName);
            Assert.AreEqual(expectedUser.LastName, result2.LastName);
        }
        [TestMethod]
        public void DetailedEditUsers_stringPara_NOT_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;
            var expectedUser = new User()
            {
                Email = "minEpost",
                FirstName = "Per",
                LastName = "Hansen",
            };
            //Act 
            var result = (RedirectToRouteResult)controller.DetailedEditUsers(expectedUser.Email);
            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Login");
        }
        [TestMethod]
        public void DetailedEditUsers_noPara_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;
            //Act
            var result = (ViewResult)controller.DetailedEditUsers();
            //Assert
            Assert.AreEqual(result.ViewName, "");
        }
        [TestMethod]
        public void DetailedEditUsers_noPara_NOT_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;
            //act
            var result = (RedirectToRouteResult)controller.DetailedEditUsers();
            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Login");
        }
        [TestMethod]
        public void DetailedEditUsers_userPara_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;
            var user = new User()
            {
                FirstName = "Per"
            };
            //Act
            var result = (RedirectToRouteResult)controller.DetailedEditUsers(user);
            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "EditUsers");
        }
        [TestMethod]
        public void DetailedEditUsers_userPara_NOT_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;
            var user = new User()
            {
                FirstName = "Per"
            };
            //act
            var result = (RedirectToRouteResult)controller.DetailedEditUsers(user);
            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Login");
        }
        [TestMethod]
        public void DetailedEditUsers_wrong_userPara_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;
            controller.ViewData.ModelState.AddModelError("Email", "En Feil skjedde.");
            var user = new User()
            {
                FirstName = ""
            };
            //act
            var result = (ViewResult)controller.DetailedEditUsers(user);
            //Assert
            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void SetMovieAvailability_OK()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;

            int id = 1;

            //Act

            var resultat = (RedirectToRouteResult)controller.SetMovieAvailability(id);

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "EditMovies");


        }
        [TestMethod]
        public void SetMovieAvailability_FAILED()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;

            int id = 1;

            //Act

            var resultat = (RedirectToRouteResult)controller.SetMovieAvailability(id);

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Login");
        }
        [TestMethod]
        public void SetUserStatus_OK()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;

            string email = "test@test.no";

            //Act

            var resultat = (RedirectToRouteResult)controller.SetUserStatus(email);

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "EditUsers");


        }
        [TestMethod]
        public void SetUserStatus_FAILED()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;

            string email = "test@test.no";

            //Act

            var resultat = (RedirectToRouteResult)controller.SetUserStatus(email);

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Login");
        }

        [TestMethod]
        public void EditMovies_OK()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;

            List<Movie> movies = new List<Movie>();
            Movie movie = new Movie()
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
            movies.Add(movie);
            movies.Add(movie);
            movies.Add(movie);


            //Act 

            var resultat = (ViewResult)controller.EditMovies();
            var resultatliste = (List<Movie>)resultat.Model;

            //Assert

            Assert.AreEqual(resultat.ViewName, "");

            for (var i = 0; i < resultatliste.Count; i++)
            {
                Assert.AreEqual(movies[i].MovieId, resultatliste[i].MovieId);
                Assert.AreEqual(movies[i].Title, resultatliste[i].Title);
                Assert.AreEqual(movies[i].Stars, resultatliste[i].Stars);
                Assert.AreEqual(movies[i].Price, resultatliste[i].Price);
                Assert.AreEqual(movies[i].Genre, resultatliste[i].Genre);
                Assert.AreEqual(movies[i].Director, resultatliste[i].Director);
                Assert.AreEqual(movies[i].ReleaseYear, resultatliste[i].ReleaseYear);
                Assert.AreEqual(movies[i].ContentRating, resultatliste[i].ContentRating);
                Assert.AreEqual(movies[i].IsAvailable, resultatliste[i].IsAvailable);
                Assert.AreEqual(movies[i].Poster, resultatliste[i].Poster);
                Assert.AreEqual(movies[i].Duration, resultatliste[i].Duration);
                Assert.AreEqual(movies[i].Storyline, resultatliste[i].Storyline);
            }

        }
        [TestMethod]
        public void EditMovies_FAILED()
        {
            var controller = setupController();
            controller.Session["adminSession"] = false;

            //Act

            var resultat = (RedirectToRouteResult)controller.EditMovies();

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Login");
        }


        [TestMethod]
        public void DetailedEditMovies_OK()
        {
            var controller = setupController();
            controller.Session["adminSession"] = true;

            // Act

            var resultat = (ViewResult)controller.DetailedEditMovies();

            // Assert

            Assert.AreEqual(resultat.ViewName, "");
            
        }
        [TestMethod]
        public void DetailedEditMovies_FAILED()
        {
            var controller = setupController();
            controller.Session["adminSession"] = false;

            // Act

            var resultat = (RedirectToRouteResult)controller.DetailedEditMovies();

            // Assert

            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Login");
        }

        [TestMethod]
        public void DetailedEditMovies_moviePara_NOT_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;
            var movie = new Movie()
            {
                Title = "Test"
            };
            //act
            var result = (RedirectToRouteResult)controller.DetailedEditMovies(movie);
            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Login");
        }
        public void DetailedEditMovies_moviePara_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;
            var movie = new Movie()
            {
                MovieId = 1,
                Title = "Test"
            };
            //Act
            var result = (ViewResult)controller.DetailedEditMovies(movie.MovieId);
            //Assert
            Assert.AreEqual(result.ViewName, "");
            var result2 = (Movie)result.Model;
            Assert.AreEqual(movie.MovieId, result2.MovieId);
            Assert.AreEqual(movie.Title, result2.Title);
        }
        [TestMethod]
        public void DetailedEditMovies_wrong_userPara_LOGGED_IN()
        {
            //Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new LunaLogic(new OrderRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["adminSession"] = true;
            controller.ViewData.ModelState.AddModelError("Email", "En Feil skjedde.");
            var movie = new Movie()
            {
                MovieId = -1,
                Title = "Test"
            };
            //act
            var result = (ViewResult)controller.DetailedEditMovies(movie.MovieId);
            //Assert
            Assert.IsTrue(result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(result.ViewName, "");
        }
        [TestMethod]
        public void DetailedAddMovies_LOGGED_IN()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;
            //Act
            var result = (ViewResult)controller.DetailedAddMovie();
            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void DetailedAddMovie_OK()
        {
            var controller = setupController();
            controller.Session["adminSession"] = true;

            // Act

            var resultat = (ViewResult)controller.DetailedEditMovies();

            // Assert

            Assert.AreEqual(resultat.ViewName, "");

        }
        [TestMethod]
        public void DetailedAddMovie_FAILED()
        {
            var controller = setupController();
            controller.Session["adminSession"] = false;

            // Act

            var resultat = (RedirectToRouteResult)controller.DetailedAddMovie();

            // Assert

            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Login");
        }

        [TestMethod]
        public void DetailedAddMovies_moviePara_LOGGED_IN()
        {
            //Arrange
            var controller = new AdminController(new LunaLogic(new AdminRepositoryStub()));
            // Setter session til true ( logget inn)
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            controller.Session["adminSession"] = true;

            Movie mov = new Movie()
            {
                Title = "Test"
            };

            //Act
            var result = (RedirectToRouteResult)controller.DetailedAddMovie(mov);

            //Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "EditMovies");
        }

        [TestMethod]
        public void DetailedAddMovies_wrongMoviePara_LOGGED_IN()
        {
            //Arrange
            var controller = new AdminController(new LunaLogic(new AdminRepositoryStub()));
            // Setter session til true ( logget inn)
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            controller.Session["adminSession"] = true;


            Movie mov = new Movie()
            {
                Title = ""
            };


            //Act
            var result = (RedirectToRouteResult)controller.DetailedAddMovie(mov);


            //Assert


            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Login");
        }

        [TestMethod]
        public void DetailedAddMovies_MoviePara_NOT_LOGGED_IN()
        {
            //Arrange
            var controller = new AdminController(new LunaLogic(new AdminRepositoryStub()));
            // Setter session til false ( logget inn)
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            controller.Session["adminSession"] = false;


            Movie mov = new Movie()
            {
                Title = "Test"
            }; ;

            //Act
            var result = (RedirectToRouteResult)controller.DetailedAddMovie(mov);

            //Assert


            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Login");
        }
        [TestMethod]
        public void EditOrder_OK()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;

            List<OrdersAndUserViewModel> orders = new List<OrdersAndUserViewModel>();
            OrdersAndUserViewModel order = new OrdersAndUserViewModel()
            {
                UserId = 1,
                FirstName = "Test",
                LastName = "Tester",
                OrderId = 2,
                DateTime = "28/10/2018",
                OrderCount = 3,
                Status = 0,
            };
            orders.Add(order);
            orders.Add(order);
            orders.Add(order);

            //Act 

            var resultat = (ViewResult)controller.EditOrders();
            var resultatliste = (List<OrdersAndUserViewModel>)resultat.Model;

            //Assert

            Assert.AreEqual(resultat.ViewName, "");

            for (var i = 0; i < resultatliste.Count; i++)
            {
                Assert.AreEqual(orders[i].UserId, resultatliste[i].UserId);
                Assert.AreEqual(orders[i].FirstName, resultatliste[i].FirstName);
                Assert.AreEqual(orders[i].LastName, resultatliste[i].LastName);
                Assert.AreEqual(orders[i].OrderId, resultatliste[i].OrderId);
                Assert.AreEqual(orders[i].DateTime, resultatliste[i].DateTime);
                Assert.AreEqual(orders[i].OrderCount, resultatliste[i].OrderCount);
                Assert.AreEqual(orders[i].Status, resultatliste[i].Status);
            }

        }
        [TestMethod]
        public void EditOrder_FAILED()
        {
            //Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;

            //Act
 
            var resultat = (RedirectToRouteResult)controller.EditOrders();

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Login");
        }

        [TestMethod]
        public void JsonListUsers_OK()
        {
            var controller = setupController();

            //Arrange
            List<UserViewModel> userlist = new List<UserViewModel>();
            byte[] bytes = { 1, 0 };
            User user = new User()
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

            for (var i = 0; i < 3; i++)
            {
                UserViewModel tmp = new UserViewModel()
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName

                };

                userlist.Add(tmp);
            }

            //Act
            string resultat = controller.JsonListUsers();
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(userlist);

            //Assert
            Assert.AreEqual(json, resultat);
        }
        
        [TestMethod]
        public void JsGetOrdersId_OK()
        {
            //Arrange
            var controller = new AdminController(new LunaLogic(new OrderRepositoryStub()));

            List<JsOrderViewModel> orderlist = new List<JsOrderViewModel>();
            JsOrderViewModel jsOrder = new JsOrderViewModel
            {
                OrderId = 0,
                OrderDate = "",
            };
            orderlist.Add(jsOrder);
            orderlist.Add(jsOrder);
            orderlist.Add(jsOrder);

            int id = 1;
            //Act
            string resultat = controller.JsGetOrdersId(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(orderlist);

            //Assert
            Assert.AreEqual(json, resultat);
        }

        [TestMethod]
        public void JsGetOrderLinesById()
        {
            //Arrange
            var controller = setupController();

            List<JsOrderLineViewModel> orderLines = new List<JsOrderLineViewModel>();
            var orderLine = new JsOrderLineViewModel()
            {
                Title = "Test",
                Price = 100
            };
            orderLines.Add(orderLine);
            orderLines.Add(orderLine);
            orderLines.Add(orderLine);

            int id = 1;
            //Act
            string resultat = controller.JsGetOrderLinesByID(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(orderLines);

            //Assert
            Assert.AreEqual(json, resultat);
        }

        [TestMethod]
        public void IsAuthorized_true()
        {
            // Arrange
            var controller = setupController();
            controller.Session["adminSession"] = true;

            // Act
            var result = controller.IsAuthorized();

            //Assert
            Assert.IsTrue(result == true);

        }

        [TestMethod]
        public void IsAuthorized_false()
        {
            // Arrange
            var controller = setupController();
            controller.Session["adminSession"] = false;

            // Act
            var result = controller.IsAuthorized();

            //Assert
            Assert.IsTrue(result == false);

        }

        [TestMethod]
        public void IsAuthorized_null()
        {
            // Arrange
            var controller = setupController();
            controller.Session["adminSession"] = null;

            // Act
            var result = controller.IsAuthorized();

            //Assert
            Assert.IsTrue(result == false);

        }
    }

}

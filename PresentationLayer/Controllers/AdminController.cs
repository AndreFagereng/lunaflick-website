using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BLL;
using Model.AdminModel;
using Model.Models;
using Model.ViewModels;

namespace PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        private string adminSession = "adminSession";
        private ILunaLogic _LunaBLL;

        public AdminController()
        {
            _LunaBLL = new LunaLogic();
        }

        public AdminController(ILunaLogic stub)
        {
            _LunaBLL = stub;
        }
        
        /// <summary>
        /// Metode som skjekker om brukeren er authorized som admin.
        /// </summary>
        /// <returns>Returnerer AdminPanel View hvis bruker er authorized</returns>
        public ActionResult Login()
		{
            if(IsAuthorized())
            {
                return RedirectToAction("AdminPanel");
            }
			return View();
		}

        /// <summary>
        /// Sjekker at kredentialer til administatorene er korrekt
        /// </summary>
        /// <param name="loginAdmin"></param>
        /// <returns></returns>

        [HttpPost]
		public ActionResult Login(Login loginAdmin)
		{
           
            if (ModelState.IsValid)
			{
                if (_LunaBLL.VerifyAdmin(loginAdmin))
                {
                    Session[adminSession] = true;
                    return RedirectToAction("AdminPanel");
                }
                else
                {
                    ModelState.AddModelError("Password", "Feil brukernavn eller passord.");
                }
            }

			return View();
		}
        /// <summary>
        /// Logger ut av admin-sessionen.
        /// </summary>
        /// <returns>Et login admin view</returns>
        public ActionResult Logout()
        {
            Session.Clear();
     
            return RedirectToAction("Login");
        }

        /// <summary>
        /// Hovedsiden til admin-panelet. Her vises statistikk på brukere og filmer.
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminPanel()
        {
            if (IsAuthorized())
            {
                var statusArray = _LunaBLL.GetCharInformation();
                var inactive = statusArray[0];
                var active = statusArray[1];
                ViewBag.statusArray = statusArray;
                return View();
            }
            return RedirectToAction("Login");
        }
       /// <summary>
       /// Endrer status på en ordre til aktiv/kansellert
       /// </summary>
       /// <param name="id">Finner gitt ordre ved id</param>
       /// <returns>Login view ved uautorisert, hvis ikke så viser den editorders med ny status på ordre</returns>
        public ActionResult SetOrderStatus(int id)
        {
            if (IsAuthorized())
            {
                byte changeSuccess = _LunaBLL.SetOrderStatus(id);
                return RedirectToAction("EditOrders");
            }
            return RedirectToAction("Login");
        }
        /// <summary>
        /// Viser ordresiden
        /// </summary>
        /// <returns></returns>
        public ActionResult UserOrders()
		{
            if(IsAuthorized())
            {
                return View();
            }
			return RedirectToAction("Login");
		}
        /// <summary>
        /// Viser en liste av alle brukerene i databasen
        /// Ved isAuthorized=true får vi se alle brukerene. Hvis ikke
        /// kommer man til login-siden
        /// </summary>
        public ActionResult EditUsers()
        {
            if (IsAuthorized())
            {
                List<User> AllUsers = _LunaBLL.ListUsers();
                return View(AllUsers);
            }
            return RedirectToAction("Login");
        }
        /// <summary>
        /// Henter data til den spesifikke brukeren.
        /// </summary>
        /// <param name="user">En brukerepost</param>
        [HttpGet]
        public ActionResult DetailedEditUsers(string user)
        {
            if (IsAuthorized())
            {
                User UserInDb = _LunaBLL.GetUser(user);
                return View(UserInDb);
            }
            return RedirectToAction("Login");
        }
        /// <summary>
        /// Viser viewet på nytt om man har feks endret status på en bruker.
        /// </summary>
        public ActionResult DetailedEditUsers()
        {
            if (IsAuthorized())
            {
                return View();
            }
            return RedirectToAction("Login");
        }
        /// <summary>
        /// Endrer en faktisk bruker
        /// </summary>
        /// <param name="user">En bruker</param>
        /// <returns>Returnerer til editusers siden hvor en ny bruker er lagt til </return>
        [HttpPost]
        public ActionResult DetailedEditUsers(User user)
        {
            if (IsAuthorized())
            {
                
                bool updatedOK = _LunaBLL.EditUser(user);
                if (updatedOK)
                {
                    return RedirectToAction("EditUsers");
                }
                else
                {
                    ModelState.AddModelError("Email", "En feil skjedde.");
                    return View();
                }
                
            }

            return RedirectToAction("Login");
        }

        /// <summary>
        /// Endrer status på en valgt film.
        /// </summary>
        public ActionResult SetMovieAvailability(int movieId)
        {
            {
                if (IsAuthorized())
                {
                    byte changeSuccess = _LunaBLL.MovieAvailabilty(movieId);
                    return RedirectToAction("EditMovies");
                }
                return RedirectToAction("Login");
            }
        }
        /// <summary>
        /// Endrer status på en valgt bruker
        /// </summary>
        public ActionResult SetUserStatus(string email)
        {
            if (IsAuthorized())
            {
                byte changeSuccess = _LunaBLL.SetUserStatus(email);
                return RedirectToAction("EditUsers");
            }
            return RedirectToAction("Login");
        }

        public ActionResult EditMovies()
        {
            if (IsAuthorized())
            {
                List<Movie> allMovies = _LunaBLL.GetMoviesById();
                return View(allMovies);
            }
            return RedirectToAction("Login");
        }
        /// <summary>
        /// Endrer en valgt film
        /// </summary>
        [HttpPost]
        public ActionResult DetailedEditMovies(Movie movie)
        {
            if (IsAuthorized())
            {

                bool updatedOK = _LunaBLL.EditMovie(movie);
                if (updatedOK)
                {
                    return RedirectToAction("EditMovies");
                }
                else
                {
                    ModelState.AddModelError("Email", "En feil skjedde.");
                    return View();
                }

            }

            return RedirectToAction("Login");
        }

        public ActionResult DetailedEditMovies()
        {
            if (IsAuthorized())
            {
                return View();
            }
            return RedirectToAction("Login");
        }
        /// <summary>
        /// Fyller inn rediger-film viewet med en valgt film.

        [HttpGet]
        public ActionResult DetailedEditMovies(int movieId)
        {
            if (IsAuthorized())
            {
                Movie movieInDb = _LunaBLL.GetMovieById(movieId);
                if(movieInDb != null)
                {
                    return View(movieInDb);
                }
                else
                {
                    ModelState.AddModelError("Email", "En feil skjedde.");
                    return View();

                }
               
            }
            return RedirectToAction("Login");
        }

        public ActionResult DetailedAddMovie()
        {
            if (IsAuthorized())
            {
                return View();
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult DetailedAddMovie(Movie movie)
        {
            if (IsAuthorized())
            {
                bool IsMovieAdded = _LunaBLL.AddMovie(movie);
                if (IsMovieAdded)
                {
                    return RedirectToAction("EditMovies");                }
                else
                {
                    ModelState.AddModelError("Title", "Noe gikk galt, prøv igjen!");
                }
            }

            return RedirectToAction("Login");
        }
       
        /// <summary>
        /// Denne metoden brukes ikke for øyeblikket, men den
        /// kan slette en bruker fullstendig fra databasen.
        /// </summary>

        public ActionResult RemoveUser(string email)
        {
            bool Deletion = _LunaBLL.RemoveUser(email);
            return RedirectToAction("EditUsers");
        }
        /// <summary>
        /// Viser alle ordre i databasen sortert etter dato
        /// </summary>
        public ActionResult EditOrders()
        {
            if (IsAuthorized())
            {
                var allOrders = _LunaBLL.GetOrdersByDate();
                return View(allOrders);
            }
            return RedirectToAction("Login");
        }

        /// <summary>
        /// brukes i javascript og ajax
        /// </summary>
        /// <returns>json-objekt av alle brukere</returns>
        public string JsonListUsers()
        {
            List<User> user = _LunaBLL.ListUsers();
            List<UserViewModel> ListOfUsers = new List<UserViewModel>();
            foreach(var item in user)
            {
               var temp = new UserViewModel { UserId = item.UserId, FirstName = item.FirstName, LastName = item.LastName };
               ListOfUsers.Add(temp);
            }

            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(ListOfUsers);
            return json;
        }
        /// <summary>
        /// Brukes i javascript og ajax
        /// <returns>Json objekt av valgt bruker sine ordre</returns>
        public string JsGetOrdersId(int UserId)
        {
            List<JsOrderViewModel> allOrders = _LunaBLL.UsersOrders(UserId);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(allOrders);
            return json;
        }
        /// <summary>
        /// Brukes i javascript og ajax
        /// </summary>
        /// <param name="OrderLineId">Navigerer med en ordre ID</param>
        /// <returns>Json objekt av valgt ordre sine ordrelinjer</returns>
        public string JsGetOrderLinesByID(int OrderLineId)
        {
            List<JsOrderLineViewModel> allOrderLines = _LunaBLL.OrderOrderlines(OrderLineId);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(allOrderLines);
            return json;
        }


        /// <summary>
        /// Sjekker om administratoren er logget inn
        /// Brukes i alle admin-metoder for autorisering
        /// </summary>
        public bool IsAuthorized()
        {
            if (Session[adminSession] != null)
            {
                bool loggedIn = (bool)Session[adminSession];
                if (loggedIn)
                {
                    return true;
                }
            }
            Session[adminSession] = false;
            return false;
        }


    }
}
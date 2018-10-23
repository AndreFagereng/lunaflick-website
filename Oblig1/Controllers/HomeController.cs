using Oblig1.Models;
using Oblig1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BLL;

namespace Oblig1.Controllers
{
    /// <summary>
    /// For øyeblikket den eneste kontrollern vi har. Styrer all kommunikasjon mellom views/viewmodellene og modellene.
    /// Har også noen metoder som går direkte i databasen, men dette skal fjernes for å ha et lag mellom databasecontexten og kontrolleren.
    /// Vi skal utvide til flere kontrollere frem til Oblig2 for å få bedre struktur.
    /// </summary>
    public class HomeController : Controller
    {
		/// <summary>
		/// ///TESTETSTSET
		/// </summary>
        private string mySessionAuthorized = "Authorized";
        private string mySessionCart = "Cart";
        private string mySessionUser = "User";
        

        /// <summary>
        /// Hovedsiden som viser alle filmene som er mulig å kjøpe.
        /// </summary>
        /// <returns>Returnerer alle filmene i databasen sortert etter sjanger.</returns>
        public ActionResult Index()
        {
            var LunaBLL = new LunaBLL();
            var AllMoviesInDb = LunaBLL.getAllMovies();
            if (Session[mySessionAuthorized] == null)
            {
                Session[mySessionAuthorized] = false;
                Session[mySessionCart] = new List<Movie>();

                ViewBag.LoggedIn = false;
            }
            else
            {
                ViewBag.LoggedIn = (bool)Session[mySessionAuthorized];
            }
            return View(AllMoviesInDb);
        }

        /// <summary>
        /// Enkel Logg-ut metode som sletter alle variabler i Session.
        /// Vi har brukt Session til å holde styr på eventuelle innlogginger
        /// samt handlekurv og til å identifisere hvem som er logget inn.
        /// </summary>
        /// <returns> Returnerer en redirect til Index metoden. </returns>
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Metoden brukes for å verifisere om brukern er logget inn eller ikke. Dette gjøres gjennom en Session-variabel
        /// </summary>
        /// <param name="user"> Tar inn en bruker og sjekker om eposten ligger i databasen</param>
        /// <returns>Returnerer en index som blir modifisert alt ettersom brukeren er logget inn eller ikke.</returns>
        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Backend validering gikk ikke igjennom, prøv igjen!";
            }
            else
            {
                var LunaBLL = new LunaBLL();
                if (LunaBLL.UserInDB(user))
                {
                    Session[mySessionAuthorized] = true;
                    Session[mySessionUser] = user.Email;
                    ViewBag.LoggedIn = true;

                    return RedirectToAction("Index");
                }
                else
                {
                    Session[mySessionAuthorized] = false;
                    ViewBag.LoggedIn = false;
                    TempData["msg"] = "Vi fant ikke " + user.Email + " i vår database!";
                }
                
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Metoden er brukt til å registrere en bruker i database.
        /// Setter en bolsk verdi for å avgjøre om metoden "AddCustomer" klarte
        /// å lagre en bruker i databasen. Vi har valgt å bruke TempData, for enkelt
        /// å kommunisere med bruker, om registreringen var velykket eller ikke.
        /// </summary>
        /// <param name="user"> Tar inn en ViewModel av typen UserViewModel </param>
        /// <returns>Returnerer en redirect til index-metoden som tar seg av session-variabelen.</returns>
        [HttpPost]
        public ActionResult Register(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var LunaBLL = new LunaBLL();
                bool ok = LunaBLL.AddCustomer(user);

                if (ok)
                {
                    //return true;
                    TempData["msg"] = "Velkommen, " + user.FirstName + "! Du kan nå logge inn.";
                    return RedirectToAction("Index");

                }

            }
            //Til senere: Bruke Viewbag.enellerannenmelding som havner i index, i stedet for å lage et nytt view. 
            TempData["msg"] = "Ops! " + user.Email + " er allerede registrert i vårt system.";
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Gir tilgang til minside om man er innlogget.
        /// </summary>
        /// <returns>Index for uautorisert. Minside om man er autorisert.</returns>
        public ActionResult MySite()
        {
            if (!IsAuthorized())
            {
                return RedirectToAction("Index");
            }
            else
            {
                var LunaBLL = new LunaBLL();
                UserViewModel user = LunaBLL.GetDetailedUser((string)Session[mySessionUser]);

                return View(user);
            }
        }


        /// <summary>
        /// En metode som sjekker om en bruker er autorisert. Skal fjernes fra kontrolleren og flyttes til et
        /// mer relevant sted. Vi har tenkt at den kan ligge i Utilities/Security.
        /// </summary>
        /// <returns>Returnerer en bolsk verdi avhengig av status til bruker-sessionen.</returns>
        public bool IsAuthorized()
        {
            if (Session[mySessionAuthorized] != null)
            {
                bool loggedIn = (bool)Session[mySessionAuthorized];
                if (loggedIn)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Metoden brukes til legge til en film i en Session variabel,
        /// som holder styr på hvilke filmer bruker har lagt til i handlekurv.
        /// Denne brukes aktivt når bruker ønsker å legge til filmer i sin handlekurv.
        /// "MovieId" blir hentet fra viewet og sjekekt opp mot databasen.
        /// TODO:
        /// Vi skal flytte denne metoden ut av Controller og inn i et repository for å skille
        /// databasen fra kontrolleren.
        /// </summary>
        /// <param name="id"> Metoden tar en ID parameter, som tilsvarer en ID i Movie-databasen </param>
        public void AddToCart(int id)
        {
            var LunaBLL = new LunaBLL();
                if (Session[mySessionCart] == null)
                {
                    var moviesInCart = new List<Movie>(); //Bytte til ViewModel?
                    var newMovie = LunaBLL.GetMovieById(id);
                    moviesInCart.Add(newMovie);
                    Session[mySessionCart] = moviesInCart;
                }
                else
                {
                    List<Movie> currentMovieList = (List<Movie>)Session[mySessionCart];
                    var newMovie = LunaBLL.GetMovieById(id);
                    currentMovieList.Add(newMovie);
                    Session[mySessionCart] = currentMovieList;
                }
        }

        
        // <summary>
        /// Går inn i session-objektet og fjerner filmen som har riktig parameter.
        /// </summary>
        /// <param name="id">Tar imot id'en til filmen man ønsker å slette.</param>
        public void RemoveFromCart(int id)
        {
            List<Movie> currentMovieList = (List<Movie>)Session[mySessionCart];
            currentMovieList.Remove(currentMovieList.FirstOrDefault(m => m.MovieId == id));
        }

        /// <summary>
        /// Sjekker om bestillingen er korrekt. Exception-handling er ikke implementert i denne utgaven.
        /// </summary>
        /// <returns>Går til minside ved velykket bestilling. Går til Index ved feil.</returns>
        public ActionResult CheckoutComplete()
        {
            try
            {
                var LunaBLL = new LunaBLL();
                bool checkoutComplete = LunaBLL.createOrder((List<Movie>)Session[mySessionCart], (string)Session[mySessionUser]);
                if (checkoutComplete)
                {
                    Session[mySessionCart] = new List<Movie>();
                    return RedirectToAction("MySite");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            } catch (Exception e)
            {
                return RedirectToAction("Index");
            }


        }

        /// <summary>
        /// Et metode som viser cart-modalen
        /// </summary>
        /// <returns>Returnerer en modal for handlekurven</returns>
        public PartialViewResult Cart()
        {
            return PartialView("cartModal");
        }

        // <summary>
        /// En modal for betalingsinformasjon. Blir validert mot javascript.
        /// </summary>
        /// <returns>Returnerer en modal for betalingsinformasjon.</returns>
        public PartialViewResult Checkout()
        {
            return PartialView("checkOutModal");
        }

        /// <summary>
        /// En modal for registrering og innlogging.
        /// </summary>
        /// <returns>Returnerer en modal for logg-inn og registrering.</returns>
        public ActionResult LogReg()
        {
            return PartialView("LoginRegisterModal");
        }

        /// <summary>
        /// Metoden viser detaljert informasjon om en valgt film i en egenmodal.
        /// </summary>
        /// <param name="id">Tar imot id'en til en film for å finne korrekt film.</param>
        /// <returns>Returnerer et partial-view med informasjon om den aktuelle filmen.</returns>
        public ActionResult GetDetailedMovie(int id)
        {
            var LunaBLL = new LunaBLL();
            return PartialView("DetailedMovieModal", LunaBLL.MovieDetail(id));
        }

        /// <summary>
        /// Gjør om en liste av ordre som tilhører kunden fra en liste av objekter til en string
        /// slik at json kan bruke det.
        /// Denne metoden skal også inn i et repository.
        /// </summary>
        /// <returns>Returnerer en streng med informasjon om alle ordrene til kunden.</returns>
        public string JsGetOrders()
        {
            var LunaBLL = new LunaBLL();
            var email = (string)Session[mySessionUser];
                var user = LunaBLL.GetUser(email);
                int userId = user.UserId;

                List<JsOrderViewModel> allOrders = LunaBLL.UsersOrders(userId);
                var jsonSerializer = new JavaScriptSerializer();
                string json = jsonSerializer.Serialize(allOrders);
                return json;
        }

            /// <summary>
            /// Metoden omgjør en liste av filmer som tilhører en ordre om til en streng.
            /// </summary>
            /// <param name="id">Id til en ordre</param>
            /// <returns>Returnerer en streng av en liste med filmer. </returns>
        public string JsLineData(int id)
        {
            var LunaBLL = new LunaBLL();
            List<JsMovieViewModel> jsMovieList = LunaBLL.OrderMovie(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(jsMovieList);
            return json;

        }

    }

}
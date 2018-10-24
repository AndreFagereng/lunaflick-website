using Model.Models;
using Model.ViewModels;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model.Models;

namespace DAL.Repositories
{

    public class OrderRepository : IOrderRepository
    {

        /// <summary>
        /// Metoden går inn i databasen via context og henter ut de korrekte ordene til brukeren
        /// som er innlogget. Når ordrene er hentet ut, blir informasjonen definert i
        /// et ViewModel objekt, som igjen blir brukt i Viewet.
        /// </summary>
        /// <param name="userid">Metoden tar inn et parameter "userid" som definerer hvilken kunde
        /// som skal ha side ordrer vist i Viewet. </param>
        /// <returns>Returnerer en liste med alle ordrer til kunden</returns>
        public List<JsOrderViewModel> UsersOrders(int userid)
        {
            using (var context = new LunaContext())
            {
                List<Order> orderList = context.Orders.Where(u => (u.User.UserId == userid)).ToList();
                List<JsOrderViewModel> jsOrderList = new List<JsOrderViewModel>();
                foreach (var ordre in orderList)
                {
                    JsOrderViewModel jsOrder = new JsOrderViewModel
                    {
                        OrderId = ordre.OrderId,
                        OrderDate = ordre.OrderDate.ToString(),
                    };
                    jsOrderList.Add(jsOrder);
                }
                return jsOrderList;
            }

        }

        /// <summary>
        /// Metoden går inn i databasen via context og henter ut alle de korrekte ordrelinjene
        /// til en ordre. Når ordrelinjene er hentet ut, blir de definert i et ViewModel objekt,
        /// som blir brukt til et View.
        /// </summary>
        /// <param name="orderId">Metoden tar inn et ordreId parameter som definerer hvilke ordrelinjer
        /// som skal hentes ut fra databasen</param>
        /// <returns>Returnerer en liste av ViewModel objekter</returns>
        public List<JsMovieViewModel> OrderMovie(int orderId)
        {
            using (var context = new LunaContext())
            {
                List<OrderLine> orderLineList = context.OrderLines.Include("Movie").Where(o => o.Order.OrderId == orderId).ToList();
                List<JsMovieViewModel> jsMovieList = new List<JsMovieViewModel>();

                foreach (var orderlinje in orderLineList)
                {
                    JsMovieViewModel m = new JsMovieViewModel()
                    {
                        Title = orderlinje.Movie.Title,
                        MovieId = orderlinje.Movie.MovieId,
                        Price = orderlinje.Movie.Price
                    };
                    jsMovieList.Add(m);
                }

                return jsMovieList;
            }
        }
        public Movie GetMovieById(int id)
        {
            using (var context = new LunaContext())
            {
                Movie newMovie = context.Movies.FirstOrDefault(m => m.MovieId == id);
                return newMovie;
            }
        }
	}
}
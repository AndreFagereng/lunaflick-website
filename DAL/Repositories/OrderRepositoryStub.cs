using Oblig1.Models;
using Oblig1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oblig1.DAL
{

    public class OrderRepositoryStub : IOrderRepository
    {

        public List<JsOrderViewModel> UsersOrders(int userid)
        {
            List<JsOrderViewModel> jsOrderList = new List<JsOrderViewModel>();
            JsOrderViewModel jsOrder = new JsOrderViewModel
            {
                OrderId = 0,
                OrderDate = "",
            };
            jsOrderList.Add(jsOrder);
            return jsOrderList;

        }

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
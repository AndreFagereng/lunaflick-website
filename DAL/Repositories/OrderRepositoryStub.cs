using Model.Models;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
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
            List<JsMovieViewModel> jsMovieList = new List<JsMovieViewModel>();
            JsMovieViewModel m = new JsMovieViewModel()
            {
                Title = "Gjøkeredet",
                MovieId = 1,
                Price = 80.00
            };
            jsMovieList.Add(m);
            jsMovieList.Add(m);
            jsMovieList.Add(m);
            return jsMovieList;
        }
        public Movie GetMovieById(int id)
        {
            Movie newMovie = new Movie
            {
                MovieId = id,
                Title = "Gjøkeredet"
            };
            return newMovie;
        }
    }
}
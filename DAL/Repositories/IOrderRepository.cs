using System.Collections.Generic;
using Model.Models;
using Model.ViewModels;

namespace DAL.Repositories
{
    public interface IOrderRepository
    {
        Movie GetMovieById(int id);
        List<JsMovieViewModel> OrderMovie(int orderId);
        List<JsOrderViewModel> UsersOrders(int userid);
    }
}
using System.Collections.Generic;
using Oblig1.Models;
using Oblig1.ViewModels;

namespace Oblig1.DAL
{
    public interface IOrderRepository
    {
        Movie GetMovieById(int id);
        List<JsMovieViewModel> OrderMovie(int orderId);
        List<JsOrderViewModel> UsersOrders(int userid);
    }
}
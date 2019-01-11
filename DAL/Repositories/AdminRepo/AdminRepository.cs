using DAL.Utilities.Security;
using Model.AdminModel;
using Model.Models;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AdminRepository : IAdminRepository
    {

        public void ErrorLog(Exception e)
        {
            string log = DateTime.Now.ToString("MMMM") + "_ErrorLog.txt";
            var ErrorLog = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + log;
            var sw = new System.IO.StreamWriter(ErrorLog, true);
            sw.WriteLine(DateTime.Now.ToString() + " " + e.Message + " " + e.InnerException);
            Debug.WriteLine("KJØRER ERRORLOG");
            sw.Close();
        }

        public bool VerifyAdmin(Login login)
        {
            Debug.WriteLine("VERIFY");
            try
            {
                using (var db = new LunaContext())
                {
                    //Logg event to file
                    db.LogFromDB();

                    AdminUser adminUser = db.AdminUsers.FirstOrDefault(u => u.Username == login.Username);
                    if (adminUser != null)
                    {
                        byte[] usedPassword = PasswordEncryption.toHash(login.Password, adminUser.Salt);
                        return (adminUser.Password.SequenceEqual(usedPassword));
                    }
                    else
                    {
                        return false;
                    }
                }
            } catch (Exception e)
            {
                ErrorLog(e);
                return false;
            }
        }
        public List<JsOrderLineViewModel> OrderOrderlines(int OrdreLineId)
        {
            try
            {
                using (var db = new LunaContext())
                {
                    System.Diagnostics.Debug.WriteLine(OrdreLineId);
                    List<OrderLine> orderLines = db.OrderLines.Include("Movie").Where(o => o.Order.OrderId == OrdreLineId).ToList();
                    List<JsOrderLineViewModel> orderlinesList = new List<JsOrderLineViewModel>();
                    System.Diagnostics.Debug.WriteLine(orderLines.Count);
                    foreach (var orderlin in orderLines)
                    {
                        orderlinesList.Add(new JsOrderLineViewModel
                        {
                            Title = orderlin.Movie.Title,
                            Price = orderlin.Movie.Price
                        });
                    }
                    return orderlinesList;
                }
            }catch(Exception e)
            {
                ErrorLog(e);
                return null;
            }
        }

        public List<User> ListUsers()
        {
            try
            {
                List<User> AllUsers = new List<User>();
                using (var db = new LunaContext())
                {

                    AllUsers = db.Users.OrderBy(u => u.UserId).ToList();
                }                
                return AllUsers;
            } catch (Exception e)
            {
                ErrorLog(e);
                return null;
            }
        }

        public bool EditUser(User user)
        {
            try
            {
                using (var db = new LunaContext())
                {
                    //Logg event to file
                    db.LogFromDB();

                    var UserInDb = db.Users.First(u => u.UserId == user.UserId);

                    UserInDb.FirstName = user.FirstName;
                    UserInDb.LastName = user.LastName;
                    UserInDb.Address = user.Address;

                    if (db.PostalAddresses.Find(user.PostalAddress.ZipCode) != null)
                    {
                        UserInDb.PostalAddress = db.PostalAddresses.FirstOrDefault(z => z.ZipCode == user.PostalAddress.ZipCode);
                    }
                    else
                    {
                        UserInDb.PostalAddress = new PostalAddress()
                        {
                            ZipCode = user.PostalAddress.ZipCode,
                            PostalArea = user.PostalAddress.PostalArea
                        };
                    }
                    //UserInDb.PostalAddress.PostalArea = user.PostalAddress.PostalArea;
                    //UserInDb.PostalAddress.ZipCode = user.PostalAddress.ZipCode;

                    db.SaveChanges();
                    return true;

                }
            } catch (Exception e)
            {
                ErrorLog(e);
                return false;
            }

        }

        public bool EditMovie(Movie movie)
        {
            try
            {
                using (var db = new LunaContext())
                {

                    //Logg event to file
                    db.LogFromDB();

                    var MovieInDb = db.Movies.First(m => m.MovieId == movie.MovieId);

                    MovieInDb.Title = movie.Title;
                    MovieInDb.Price = movie.Price;
                    MovieInDb.ReleaseYear = movie.ReleaseYear;
                    MovieInDb.ContentRating = movie.ContentRating;
                    MovieInDb.Director = movie.Director;
                    MovieInDb.Duration = movie.Duration;
                    MovieInDb.Genre = movie.Genre;
                    MovieInDb.Storyline = movie.Storyline;

                    db.SaveChanges();
                    return true;

                }
            } catch (Exception e)
            {
                ErrorLog(e);
                return false;
            }

        }

        public bool RemoveUser(string Email)
        {
            try
            {
                using (var context = new LunaContext())
                {
                    var userToDelete = context.Users.FirstOrDefault(e => e.Email == Email);
                    if (userToDelete != null)
                    {
                        var orders = context.Orders.Include("OrderLine").Where(u => u.User.UserId == userToDelete.UserId).ToList();

                        foreach (var order in orders)
                        {
                            var orderlines = context.OrderLines.Where(u => u.Order.OrderId == order.OrderId).ToList();
                            context.Orders.Remove(order);

                            foreach (var orderline in orderlines)
                            {
                                context.OrderLines.Remove(orderline);
                            }
                        }
                        context.Users.Remove(userToDelete);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            } catch (Exception e)
            {
                ErrorLog(e);
                return false;
            }

        }

        public List<Movie> GetMoviesById()
        {
            try
            {
                List<Movie> moviesById = new List<Movie>();
                using (var context = new LunaContext())
                {
                    moviesById = context.Movies.OrderBy(i => i.MovieId).ToList();
                }
                return moviesById;
            } catch (Exception e)
            {
                ErrorLog(e);
                return null;
            }
        }





        public byte MovieAvailabilty(int id)
        {
            try
            {
                using (var context = new LunaContext())
                {
                    var movie = context.Movies.FirstOrDefault(i => i.MovieId == id);
                    {
                        if (movie.IsAvailable == 1)
                        {
                            movie.IsAvailable = 0;
                            context.SaveChanges();
                        }
                        else
                        {
                            movie.IsAvailable = 1;
                            context.SaveChanges();
                        }
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                ErrorLog(e);
                return 0;
            }
        }

        public bool AddMovie(Movie movie)
        {
            try {
                using (var db = new LunaContext())
                {
                    //Logg event to file
                    db.LogFromDB();

                    if (movie != null)
                    {
                        Movie newMovie = new Movie
                        {
                            Title = movie.Title,
                            Director = movie.Director,
                            ContentRating = movie.ContentRating,
                            IsAvailable = 1,
                            Genre = movie.Genre,
                            Duration = movie.Duration,
                            Price = movie.Price,
                            Storyline = movie.Storyline,
                            ReleaseYear = movie.ReleaseYear,
                            Poster = movie.Poster,
                            Stars = movie.Stars
                        };

                        db.Movies.Add(newMovie);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }catch(Exception e)
            {
                ErrorLog(e);
                return false;
            }
        }

        public byte SetUserStatus(string email)
        {
            try
            {
                using (var db = new LunaContext())
                {
                    //Logg event to file
                    db.LogFromDB();

                    var user = db.Users.FirstOrDefault(i => i.Email == email);
                    {
                        if (user.AccountStatus == 1)
                        {
                            user.AccountStatus = 0;
                            db.SaveChanges();
                        }
                        else
                        {
                            user.AccountStatus = 1;
                            db.SaveChanges();
                        }
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                ErrorLog(e);
                return 0;
            }
        }
        public byte GetUserStatus(string email)
        {
            try
            {
                using (var context = new LunaContext())
                {
                    var user = context.Users.FirstOrDefault(i => i.Email == email);
                    if (user.AccountStatus == 1)
                    {
                        return 1;
                    }
                    else
                        return 0;
                }
            }
            catch (Exception e)
            {
                ErrorLog(e);
            }
            return 0;
        }
        public List<Order> GetOrdersById()
        {
            try
            {
                List<Order> ordersById = new List<Order>();
                using (var context = new LunaContext())
                {
                    ordersById = context.Orders.OrderBy(i => i.OrderId).ToList();
                }
                return ordersById;
            }
            catch (Exception e)
            {
                ErrorLog(e);
                return null;
            }
        }

        public List<OrdersAndUserViewModel> GetOrdersByDate()
        {
            try
            {
                using (var context = new LunaContext())
                {
                    List<Order> orderList = context.Orders.Include("User").Include("OrderLine").OrderByDescending(o => o.OrderId).ToList();
                    List<OrdersAndUserViewModel> theList = new List<OrdersAndUserViewModel>();

                    foreach (var item in orderList)
                    {
                        OrdersAndUserViewModel m = new OrdersAndUserViewModel()
                        {
                            UserId = item.User.UserId,
                            FirstName = item.User.FirstName,
                            LastName = item.User.LastName,
                            OrderId = item.OrderId,
                            DateTime = item.OrderDate.ToString("dd/M/yyyy"),
                            OrderCount = item.OrderLine.Count(),
                            Status = item.Status
                        };
                        theList.Add(m);
                    }

                    return theList;
                }
            }catch(Exception e)
            {
                ErrorLog(e);
                return null;
            }
        }

        public int[] GetCharInformation()
        {
            int[] activeCount = { 0, 0, 0, 0 };
            try
            {
                using (var context = new LunaContext())
                {
                    activeCount[0] = context.Users.Where(u => u.AccountStatus == 0).Count();
                    activeCount[1] = context.Users.Where(u => u.AccountStatus == 1).Count();
                    activeCount[2] = context.Movies.Where(s => s.IsAvailable == 0).Count();
                    activeCount[3] = context.Movies.Where(s => s.IsAvailable == 1).Count();
                    return activeCount;
                }
            }
            catch (Exception e)
            {
                ErrorLog(e);
                return null;
            }
        }

        public byte SetOrderStatus(int id)
        {
            try
            {
                using (var db = new LunaContext())
                {
                    //Logg event to file
                    db.LogFromDB();

                    var order = db.Orders.FirstOrDefault(i => i.OrderId == id);
                    {
                        if (order.Status == 1)
                        {
                            order.Status = 0;
                            db.SaveChanges();
                        }
                        else
                        {
                            order.Status = 1;
                            db.SaveChanges();
                        }
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                ErrorLog(e);
                return 0;
            }
        }


    }
}

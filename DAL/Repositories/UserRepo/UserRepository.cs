using Model.Models;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using DAL.Utilities.Security;

namespace DAL.Repositories
{
    /// <summary>
    /// Fungerer som et layer mellom kontroller og databasen slik at
    /// kontrolleren ikke har direkte akksess til databasecontexten.
    /// Vi ønsker etterhvert å implementere interfaces og benyttes oss av dependency injection.
    /// Dette vil skje senere da vi ikke har nok kunnskap om dette ennå.
    /// </summary>
	public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Oppretter en ordre til en aktuell bruker og oppdaterer databasecontexten.
        /// </summary>
        /// <param name="movieList">Tar inn en liste av filmer.</param>
        /// <param name="userEmail">Tar inn en bruker-epost som fungerer som id og navigasjon.</param>
        /// <returns></returns>


        public bool createOrder(List<Movie> movieList, string userEmail)
        {

            using (var context = new LunaContext())
            {

                try
                {
                    var order = new Order();
                    var newOrderLines = new List<OrderLine>();
                    order.User = context.Users.FirstOrDefault(m => m.Email == userEmail);
                    order.OrderDate = DateTime.Now;
                    order.OrderLine = newOrderLines;


                    foreach (var movie in movieList)
                    {
                        var newOrderLine = new OrderLine();
                        newOrderLine.Movie = context.Movies.FirstOrDefault(m => m.MovieId == movie.MovieId);
                        newOrderLine.Order = order;
                        order.OrderLine.Add(newOrderLine);
                    }

                    context.Orders.Add(order);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }

        }

        /// <summary>
        /// Legger inn en ny bruker i user-tabellen. Postaddressene legges ikke dobbelt
        /// slik at vi slipper dobbeltlagring. Et problem nå er at hvis noen lager en postnummer
        /// med feil poststed, vil alle andre med samme postnummer få dette poststedet også.
        /// Vi har planlagt å bruke Posten sitt API for å fylle databasen vår med postnumre og
        /// auto-fylle posted for å unngå dette. Her er det også en try-catch vi må håndtere.
        /// </summary>
        /// <param name="inUser">Tar inn en bruker</param>
        /// <returns>returnerer en bolsk verdi avhengig av om registreringen var velykket eller ikke.</returns>


        public bool AddCustomer(UserViewModel inUser)
        {

            using (var context = new LunaContext())
            {
                try
                {
                    if (context.Users.FirstOrDefault(u => u.Email == inUser.Email) != null)
                    {
                        return false;
                    }
                    var newUser = new User()
                    {
                        FirstName = inUser.FirstName,
                        LastName = inUser.LastName,
                        Address = inUser.Address,
                        AccountStatus = 1
                    };

                    //Legger inn nytt postnr og poststed hvis det ikke allerede finnes i databasen.
                    if (context.PostalAddresses.Find(inUser.ZipCode) != null)
                    {
                        newUser.PostalAddress = context.PostalAddresses.FirstOrDefault(z => z.ZipCode == inUser.ZipCode);
                    }
                    else
                    {
                        newUser.PostalAddress = new PostalAddress()
                        {
                            ZipCode = inUser.ZipCode,
                            PostalArea = inUser.PostalArea
                        };
                    }

                    newUser.Email = inUser.Email;

                    var salt = PasswordEncryption.addSalt();
                    newUser.Salt = salt;
                    newUser.Password = PasswordEncryption.toHash(inUser.Password, salt);

                    context.Users.Add(newUser);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }
            }
        }


        // <summary>
        /// Sjekker om den aktuelle brukeren ligger i databasen. Epostene er
        /// unike og hvis en epost allerede ligger i databasen vil denne metoden
        /// returnere false.
        /// </summary>
        /// <param name="user">Tar imot en bruker og sjekker eposten.</param>
        /// <returns>Returnerer true om brukern ble lagt til, og false om den allerede eksisterer.</returns>
		public bool UserInDB(UserViewModel user)
        {
            using (var db = new LunaContext())
            {
                User authUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
                if (authUser != null)
                {
                    byte[] usedPassword = PasswordEncryption.toHash(user.Password, authUser.Salt);
                    return (authUser.Password.SequenceEqual(usedPassword));
                }

                else
                {
                    return false;
                }
            }

        }

        /// <summary>
        /// Metoden returnerer en UserViewModel med informasjon om den aktuelle brukeren.
        /// Her må vi håndtere catchen slik at den gjør noe vettugt.
        /// </summary>
        /// <param name="userEmail">Her bruker vi igjen epost som det unike attributten</param>
        /// <returns>Returnerer informasjon om brukeren om brukeren ligger i databasen.</returns>
		public UserViewModel GetDetailedUser(string userEmail)
        {
            using (var context = new LunaContext())
            {
                try
                {
                    var user = context.Users.Include("PostalAddress").SingleOrDefault(u => u.Email == userEmail);
                    UserViewModel userViewModel = new UserViewModel()
                    {

                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address = user.Address,
                        Email = user.Email,
                        PostalArea = user.PostalAddress.PostalArea,
                        ZipCode = user.PostalAddress.ZipCode
                    };

                    return userViewModel;

                }
                catch (Exception e)
                {
                    // Må feilhåndteres!
                    return null;
                }
            }
        }

        public User GetUser(string Email)
        {
            using (var context = new LunaContext())
            {
                var user = context.Users.Include("PostalAddress").FirstOrDefault(u => u.Email == Email);

                return user;
            }
        }

    }
}
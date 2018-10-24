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

	public class UserRepositoryStub : IUserRepository
    {
        public bool createOrder(List<Movie> movieList, string userEmail)
        {
            if(userEmail == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AddCustomer(UserViewModel inUser)
        {
            if(inUser.FirstName == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
		public bool UserInDB(UserViewModel user)
        {
            if (user.FirstName == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

		public UserViewModel GetDetailedUser(string userEmail)
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                FirstName = "Per",
                LastName = "Hansen",
                Address = "Askerveien 82",
                Email = userEmail,
                PostalArea = "Asker",
                ZipCode = "0123"
            };
            return userViewModel;
        }

        public User GetUser(string email)
        {
            User per = new User()
            {
                Email = email,
                FirstName = "Per",
                LastName = "Hansen"
            };
            return per;
        }
    }
}
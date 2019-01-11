using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Model.Models
{
    // <summary>
    /// Representerer attributtene i databasetabellen Users.
    /// </summary>
	public class User
	{
		public int UserId { get; set; }
        
		public string Email { get; set; }
        
        public byte[] Password { get; set; }
		public byte[] Salt { get; set; }
       
        public string FirstName { get; set; }
        
        public string LastName { get; set; }    
        
        public string Address { get; set; }
		public bool AdminPrivileges { get; set; }
        public byte AccountStatus { get; set; }
		public virtual PostalAddress PostalAddress { get; set; }
		public virtual List<Order> OrderList { get; set; }


	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Models
{
    // <summary>
    /// Representerer attributtene i databasetabellen PostalAddresses.
    /// </summary>
	public class PostalAddress
	{
		[Key]        
        public string ZipCode { get; set; }
       
        public string PostalArea { get; set; }
	}
}
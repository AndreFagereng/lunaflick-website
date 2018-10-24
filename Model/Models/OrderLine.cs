using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Models
{
	public class OrderLine
	{
        /// <summary>
        /// Representerer attributtene i databasetabellen OrderLines.
        /// </summary>
        public int OrderLineId { get; set; }
		public Movie Movie { get; set; }
		public Order Order { get; set; }
	}
}
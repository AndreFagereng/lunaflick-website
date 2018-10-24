using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Models
{
    /// <summary>
    /// Representerer attributtene i databasetabellen Orders.
    /// </summary>
	public class Order
	{
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public User User { get; set; }
		public List<OrderLine> OrderLine { get; set; }
	}
}
using Oblig1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1.ViewModels
{
	public class CartViewModel
	{
		public List<MovieViewModel> Movies { get; set; }
		public UserViewModel User { get; set; }
	}
}
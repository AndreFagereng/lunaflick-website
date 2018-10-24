using Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.ViewModels
{
	public class MovieViewModel
	{
		public int MovieId { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }
		public string Storyline { get; set; }
		public string Director { get; set; }
		public string Duration { get; set; }
		public string ReleaseYear { get; set; }
		public double Price { get; set; }
		public double Stars { get; set; }
		public string ContentRating { get; set; }
		public string Poster { get; set; }
		public List<Movie> Movies { get; set; }
	}
}
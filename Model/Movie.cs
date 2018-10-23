using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig1.Models
{
    // <summary>
    /// Representerer attributtene i databasetabellen Movies.
    /// </summary>
	public class Movie
	{
        
		public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Storyline { get; set; }
        //[Display(Name = "Regissør")]
        public string Director { get; set; }
        //[Display(Name = "Spilletid")]
        public string Duration { get; set; }
        //[Display(Name = "Utgivelsesår")]
        public string ReleaseYear { get; set; }
        //[Display(Name = "Pris")]
        public double Price { get; set; }
		public double Stars { get; set; }
        //[Display(Name = "Aldersgrense")]
        public string ContentRating { get; set; }
		public string Poster { get; set; }
        public List<OrderLine> OrderLine { get; set; }


	}
}
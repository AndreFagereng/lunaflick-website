using Oblig1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1.ViewModels
{
    public class MovieListViewModel
    {
        public string listName { get; set; }
        public List<Movie> List { get; set; }
    }
}
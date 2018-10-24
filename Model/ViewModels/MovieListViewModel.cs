using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.ViewModels
{
    public class MovieListViewModel
    {
        public string listName { get; set; }
        public List<Movie> List { get; set; }
    }
}
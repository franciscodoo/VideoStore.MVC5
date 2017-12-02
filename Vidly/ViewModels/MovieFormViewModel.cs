using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public string Action { get; set;}
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }

    }
}
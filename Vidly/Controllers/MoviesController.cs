using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie{Id = 1, Name = "Les Miserables"},
                new Movie{Id = 2, Name = "Monty Python"}
            };
            return View(movies);
        }

        //[Route("movies/released/{year:regex(\\d{4):min(1900)}/{month:regex(\\d{2})}")]
        [Route("movies/released/{year:min(1900)}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content("Movies released on " + year + "/" + month + ":");
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Les Miserables" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Fonseca Galhão"},
                new Customer {Name = "Sancho Paulo"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}
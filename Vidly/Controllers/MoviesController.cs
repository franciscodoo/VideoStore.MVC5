using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Les Miserables" };
            return View(movie);
        }

        //[Route("movies/released/{year:regex(\\d{4):min(1900)}/{month:regex(\\d{2})}")]
        [Route("movies/released/{year:min(1900)}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content("Movies released on " + year + "/" + month + ":");
        }
    }
}
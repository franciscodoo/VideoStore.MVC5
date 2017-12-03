using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        #region DbContext
        //We need DbContext to access db. private by convention
        private ApplicationDbContext _context;

        public MoviesController()
        {
            //needs to be initialized in the constructor
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //ApplicationDbContext this is a disposable object. override Dispose from the base Controller class
            _context.Dispose();
        }
        #endregion

        public ActionResult New()
        {
            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                Action = "Create",
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.First(x => x.Id == id);
            MovieFormViewModel viewModel = new MovieFormViewModel(movie)
            {
                Action = "Edit",
                Genres = _context.Genres.ToList()
            };


            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //++ Helper method on View 
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid) //Check if model is valid
            {
                //To add validation - 3 steps:
                //1. Add Data Annotations ~ attributes ~ to model props
                //2. Use ModelState to change flow of the program when needed
                //3. Add validation messages (view)

                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0) //new Movie
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else //existing movie
            {
                var movieInDb = _context.Movies.First(x => x.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Index()
        {
            List<Movie> movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        [Route("movies/detail/{id:min(0)}")]
        public ActionResult Detail(int id)
        {
            Movie movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //[Route("movies/detail/{id:min(0)}")]
        //public ActionResult Detail(int id)
        //{
        //    Movie movie = GetMovieById(id);
        //    return View(movie);
        //}

        //// GET: Movie
        //public ActionResult Index()
        //{
        //    var movies = GetAllMovies();

        //    return View(movies);
        //}

        //[Route("movies/detail/{id:min(0)}")]
        //public ActionResult Detail(int id)
        //{
        //    Movie movie = GetMovieById(id);
        //    return View(movie);
        //}

        ////[Route("movies/released/{year:regex(\\d{4):min(1900)}/{month:regex(\\d{2})}")]
        //[Route("movies/released/{year:min(1900)}/{month:range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content("Movies released on " + year + "/" + month + ":");
        //}

        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Les Miserables" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Fonseca Galhão"},
        //        new Customer {Name = "Sancho Paulo"},
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        //public List<Movie> GetAllMovies()
        //{
        //    var movies = new List<Movie>
        //    {
        //        new Movie{Id = 1, Name = "Les Miserables"},
        //        new Movie{Id = 2, Name = "Monty Python"}
        //    };

        //    return movies;
        //}

        //public Movie GetMovieById(int id)
        //{
        //    var movies = new List<Movie>
        //    {
        //        new Movie{Id = 1, Name = "Les Miserables"},
        //        new Movie{Id = 2, Name = "Monty Python"}
        //    };

        //    return movies.First(x => x.Id == id);
        //}
    }
}
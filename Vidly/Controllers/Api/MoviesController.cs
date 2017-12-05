using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        #region ApplicationDbContext
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        #endregion

        //GET api/movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>));
        }

        //GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        // PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //existing obj passed as 2nd arg to track changes to it
            Mapper.Map(movieDTO, movieInDb);
            _context.SaveChanges();
        }

        //DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}

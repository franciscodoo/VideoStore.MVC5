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

    }
}

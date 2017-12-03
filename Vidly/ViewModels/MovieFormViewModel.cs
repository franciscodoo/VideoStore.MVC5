using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public string Action { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        //public Movie Movie { get; set; }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 99)]
        [Required]
        public int NumberInStock { get; set; }

        [Required]
        public short? GenreId { get; set; }


        public MovieFormViewModel()
        {
            Id = 0; //ensure that the hiddenfield is populated
        }

        public MovieFormViewModel(Movie movie)
        {
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }

    }
}
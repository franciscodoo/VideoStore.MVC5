using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name="Number in Stock")]
        public int NumberInStock { get; set; }

        //If [Required] here: Error on e.g. add movie because prop'd be null. in form is GenreId not Genre itself
        public Genre Genre { get; set; }

        [Required]
        public short GenreId { get; set; }
    }
}
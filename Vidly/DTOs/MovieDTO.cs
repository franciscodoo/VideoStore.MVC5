using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class MovieDTO
    {
        [Required]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }

        [Required]
        public short GenreId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public short Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
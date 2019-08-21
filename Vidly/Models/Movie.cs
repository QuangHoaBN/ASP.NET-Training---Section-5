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
        [Required(ErrorMessage ="Please enter Movie's name")]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdd { get; set; }
        [StockRange1to20]
        [Range(1,20)]
        public int Stock { get; set; }
        public int NumberAvailable { get; set; }
    }
}
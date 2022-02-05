using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly_.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }
        
        [Required]
        [Display(Name="Genre")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }
        
        [Required]
        [Display(Name="Released Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name="Number In Stock")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }
        public byte NumberAvaliable { get; set; }
    }
}
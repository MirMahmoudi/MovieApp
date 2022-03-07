using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieApp.Models;

namespace MovieApp.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20!")]
        [Required]
        public int? NumberInStock { get; set; }

        public int? NumberAvailable { get; set; }

        public string Title
        {
            get { return Id == 0 ? "New Movie" : "Edit Movie"; }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie mvoie)
        {
            Id = mvoie.Id;
            Name = mvoie.Name;
            GenreId = mvoie.GenreId;
            ReleaseDate = mvoie.ReleaseDate;
            NumberInStock = mvoie.NumberInStock;
        }

        public MovieFormViewModel(MovieFormViewModel mvoie)
        {
            Id = mvoie.Id;
            Name = mvoie.Name;
            GenreId = mvoie.GenreId;
            ReleaseDate = mvoie.ReleaseDate;
            NumberInStock = mvoie.NumberInStock;
        }
    }
}
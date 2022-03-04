using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
    }
}
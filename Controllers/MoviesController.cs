using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movie1 = new Movie
            {
                Name = "Die Hard"
            };
            
            var movie2 = new Movie
            {
                Name = "Forest Gump"
            };

            var moviesList = new List<Movie>();
            moviesList.Add(movie1);
            moviesList.Add(movie2);

            var movies = new MoviesViewModel { Movies = moviesList };

            return View(movies);
        }
    }
}
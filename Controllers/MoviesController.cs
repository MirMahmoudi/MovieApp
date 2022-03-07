using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;
using MovieApp.ViewModels;
using System.Data.Entity;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = new MoviesViewModel
            {
                Movies = _context.Movies.Include(m => m.Genre).ToList()
            };

            return View(movies);
        }

        //GET: Movies/Details/id
        public ActionResult Details(int id)
        {
            var movieInDb = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if(movieInDb == null)
                return HttpNotFound();

            var movie = new MoviesViewModel { Movie = movieInDb };

            return View(movie);
        }

        // GET: /Movies/New
        public ActionResult New()
        {
            var movieFormViewModel = new MovieFormViewModel { Genres = _context.Genres };

            return View("MovieForm", movieFormViewModel);
        }

        // POST: /Movies/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(MovieFormViewModel movie)
        {
            if (ModelState.IsValid)
            {
                var movieInDB = new Movie()
                {
                    Name = movie.Name,
                    GenreId = movie.GenreId,
                    ReleaseDate = (DateTime)movie.ReleaseDate,
                    NumberInStock = (int)movie.NumberInStock,
                    DateAdded = DateTime.Now,
                    NumberAvailable = movie.NumberAvailable == null
                                      ? (int)movie.NumberInStock
                                      : (int)movie.NumberAvailable
                };

                _context.Movies.Add(movieInDB);
                _context.SaveChanges();

                return RedirectToAction("Index", "Movies");
            }

            var movieFormViewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres
            };

            return View("MovieForm", movieFormViewModel);
        }

        // GET: /Movies/Edit/id
        public ActionResult Edit(int id)
        {
            var movieInDb = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return HttpNotFound();

            var movie = new MovieFormViewModel(movieInDb)
            {
                Genres = _context.Genres
            };

            return View("MovieForm", movie);
        }

        // POST: /Movies/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieFormViewModel movie)
        {
            if (ModelState.IsValid)
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

                if (movieInDb == null)
                    return HttpNotFound();

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = (DateTime)movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = (int)movie.NumberInStock;

                _context.SaveChanges();

                return RedirectToAction("Index", "Movies");
            };

            var movieFormViewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres
            };

            return View("MovieForm", movieFormViewModel);
        }
    }
}
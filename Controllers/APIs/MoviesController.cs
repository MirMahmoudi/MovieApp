using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieApp.Models;
using MovieApp.ViewModels;
using System.Data.Entity;

namespace MovieApp.Controllers.APIs
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/Movies
        public IEnumerable<Movie> GetMovies()
        {
            var moviesInDb = _context.Movies.Include(m => m.Genre).ToList();

            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return moviesInDb;
        }

        // GET: /api/Movies/id
        public Movie GetMovie(int id)
        {
            var movieInDb = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return movieInDb;
        }

        // POST: /api/Movies
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var movieInDb = movie;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.NumberAvailable = movie.NumberAvailable != 0 ?
                    movie.NumberAvailable :
                    movie.NumberInStock;

                _context.Movies.Add(movieInDb);
                _context.SaveChanges();

                return movieInDb;
            };

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // PUT: /api/Movies/id
        [HttpPut]
        public Movie UpdateMovie(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

                if (movieInDb == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.NumberAvailable = movie.NumberAvailable;

                _context.SaveChanges();

                return movieInDb;
            };

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // DELETE: /api/Movies/id
        public Movie DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return movieInDb;
        }
    }
}

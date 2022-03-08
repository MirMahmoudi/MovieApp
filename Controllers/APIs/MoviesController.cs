using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieApp.Models;
using MovieApp.Dtos;
using System.Data.Entity;
using AutoMapper;

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
        public IEnumerable<MovieDto> GetMovies()
        {
            var moviesDto = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            if (moviesDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return moviesDto;
        }

        // GET: /api/Movies/id
        public MovieDto GetMovie(int id)
        {
            var movieInDb = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return (Mapper.Map<Movie, MovieDto>(movieInDb));
        }

        // POST: /api/Movies
        [HttpPost]
        public MovieDto CreateMovie(MovieDto movieDto)
        {
            if (ModelState.IsValid)
            {
                var movie = Mapper.Map<MovieDto, Movie>(movieDto);
                movie.DateAdded = DateTime.Now;
                movieDto.DateAdded = DateTime.Now;

                _context.Movies.Add(movie);
                _context.SaveChanges();

                movieDto.Id = movie.Id;
                return movieDto;
            };

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // PUT: /api/Movies/id
        [HttpPut]
        public MovieDto UpdateMovie(int id, MovieDto movieDto)
        {
            if (ModelState.IsValid)
            {
                var movieInDb = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

                if (movieInDb == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                Mapper.Map(movieDto, movieInDb);

                _context.SaveChanges();

                return movieDto;
            };

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // DELETE: /api/Movies/id
        public MovieDto DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Mapper.Map<Movie, MovieDto>(movieInDb);
        }
    }
}

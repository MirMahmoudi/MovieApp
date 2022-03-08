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
        public IHttpActionResult GetMovies()
        {
            var moviesDto = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            if (moviesDto == null)
                return NotFound();

            return Ok(moviesDto);
        }

        // GET: /api/Movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }

        // POST: /api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (ModelState.IsValid)
            {
                var movie = Mapper.Map<MovieDto, Movie>(movieDto);
                movie.DateAdded = DateTime.Now;
                movieDto.DateAdded = DateTime.Now;

                _context.Movies.Add(movie);
                _context.SaveChanges();

                movieDto.Id = movie.Id;

                // URI: Unified Resource Identifier
                return Created(new Uri($"{Request.RequestUri}{movie.Id}"), movieDto);
            };

            return BadRequest();
        }

        // PUT: /api/Movies/id
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (ModelState.IsValid)
            {
                var movieInDb = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

                if (movieInDb == null)
                    return NotFound();

                Mapper.Map(movieDto, movieInDb);

                _context.SaveChanges();

                return Ok(movieDto);
            };

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // DELETE: /api/Movies/id
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }
    }
}

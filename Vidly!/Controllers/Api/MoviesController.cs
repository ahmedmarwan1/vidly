using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_.Models;
using Vidly_.DTOS;
using AutoMapper;

namespace Vidly_.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //Get /api/movies
        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(c => c.Genre)
                .Where(m => m.NumberAvaliable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));

            return  moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            
        }
        // Get /api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie==null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        //Post /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        //Put /api/movies/id
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();

            movieDto.Id = movieInDb.Id;
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok(movieDto);
        }
        //Delete /api/movies/id
        [HttpDelete]
        public IHttpActionResult Deletemovie(int id,MovieDto movieDto)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok(Mapper.Map(movieInDb, movieDto));
        }
    }
}

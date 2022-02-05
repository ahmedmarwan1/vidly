using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using Vidly_.Models;
namespace Vidly_.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c=>c.Id==id);
            return View(movie);
        }
        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewmodel = new NewMovieViewModel 
            {
                Movie = new Movie(),
                Genres = genre
            };
            return View("New", viewmodel);
        }
        [Authorize(Roles=RoleName.CanManageMovies)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel 
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("New", viewModel);
            }
            if(movie.Id==0)
            {
                movie.DateAdded=DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }
        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            
            var viewModel = new NewMovieViewModel 
            { 
                    Movie=  movie,
                    Genres = _context.Genres.ToList()
            };
            
            return View("New", viewModel);
        }
    }
}
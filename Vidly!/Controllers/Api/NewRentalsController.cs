using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_.DTOS;
using System.Data.Entity;
using Vidly_.Models;
using AutoMapper;
  
namespace Vidly_.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Rental> GetRentals()
        {
            var rentals = _context.Rentals
                .Include(c => c.Customer)
                .Include(c => c.Movie)
                .ToList();
            return rentals;
        }
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            var customer = _context.Customers
                .Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies
                .Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvaliable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvaliable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}

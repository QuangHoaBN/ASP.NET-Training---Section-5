using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
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
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie=new Movie(),
                Genres=genres
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            //Nếu lỗi thì load lại
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("New", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdd = movie.DateAdd;
                movieInDb.Stock = movie.Stock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Hello Sir!" };
            var customer = new List<Customer>
            {
                new Customer()
                {
                    Name="Customer 1"
                },
                new Customer()
                {
                    Name="Customer 2"
                },
                new Customer()
                {
                    Name="Customer 3"
                },
                new Customer()
                {
                    Name="Customer 4"
                }
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customer
            };
            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m=>m.Id==id);
            if (movie == null) return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres=_context.Genres.ToList()
            };
            return View("New",viewModel);
        }
        //GET /movies/index
        public ViewResult Index()
        {
            return View();
        }
    }
}
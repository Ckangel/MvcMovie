using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Linq;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? searchYear)
        {
            var movies = from m in _context.Movie
                         select m;

            if (searchYear.HasValue)
            {
                movies = movies.Where(m => m.ReleaseDate.Year >= searchYear.Value);
            }

            return View(movies.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
    }
}

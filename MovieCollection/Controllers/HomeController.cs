using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDbContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Podcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieEntry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterMovie(Movie m)
        {
            //make sure there are no errors
            if (ModelState.IsValid)
            {
                //add the movie to the database
                _context.Movies.Add(m);
                _context.SaveChanges();
                return View("Confirmation", m);
            }
            //send back the same page with validation summary if there are errors
            else
            {
                return View();
            }
        }
        public IActionResult MovieList()
        {
            return View(_context.Movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

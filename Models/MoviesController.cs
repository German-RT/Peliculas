using Microsoft.AspNetCore.Mvc;
using Tarea_2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tarea_2.Controllers
{
    public class MoviesController : Controller
    {
        private static readonly Dictionary<string, string> Categories = new()
        {
            { "accion", "Acción" },
            { "comedia", "Comedia" },
            { "ciencia-ficcion", "Ciencia Ficción" },
            { "romance", "Romance" }
        };

        private static readonly List<Movie> LoadedMovies = new()
        {
            new Movie
            {
                Id = 1,
                Title = "Spider-Man: No Way Home",
                Description = "Peter Parker enfrenta las consecuencias de su identidad revelada.",
                Category = "accion",
                Year = 2021,
                PosterUrl = "https://image.tmdb.org/t/p/w500/1g0dhYtq4irTY1GPXvft6k4YLjm.jpg"
            },
            new Movie
            {
                Id = 2,
                Title = "Soul",
                Description = "Un músico viaja al más allá y descubre el verdadero significado de la vida.",
                Category = "comedia",
                Year = 2020,
                PosterUrl = "https://image.tmdb.org/t/p/w500/hm58Jw4Lw8OIeECIq5qyPYhAeRJ.jpg"
            },
            new Movie
            {
                Id = 3,
                Title = "Interstellar",
                Description = "Un grupo de exploradores viaja a través de un agujero de gusano para salvar a la humanidad.",
                Category = "ciencia-ficcion",
                Year = 2014,
                PosterUrl = "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg"
            },
            new Movie
            {
                Id = 4,
                Title = "La La Land",
                Description = "Una historia de amor entre una actriz y un músico en Los Ángeles.",
                Category = "romance",
                Year = 2016,
                PosterUrl = "https://image.tmdb.org/t/p/w500/uDO8zWDhfWwoFdKS4fzkUJt0Rf0.jpg"
            }
        };

        public IActionResult Index(string? id = null)
        {
            List<Movie> filteredMovies;

            if (!string.IsNullOrEmpty(id) && Categories.ContainsKey(id))
            {
                filteredMovies = LoadedMovies.Where(m => m.Category == id).ToList();
                ViewBag.GenreName = Categories[id];
            }
            else
            {
                filteredMovies = LoadedMovies;
                ViewBag.GenreName = "Todas";
            }

            ViewBag.Categories = Categories;
            return View(filteredMovies);
        }

        [HttpGet]
        public IActionResult Suggest()
        {
            return View(new SuggestedMovie());
        }


        [HttpPost]
        public IActionResult Suggest(SuggestedMovie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}

using FilmyApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmyApp.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film(){Id = 1, Name = "Film1", Description = "opis filmu1", Price=3},
            new Film(){Id = 2, Name = "Film2", Description = "opis filmu2", Price=5},
            new Film(){Id = 3, Name = "Film3", Description = "opis filmu3", Price=3},
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(films);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Film());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Film film)
        {
            var existingFilm = films.FirstOrDefault(x => x.Id == id);
            if (existingFilm == null)
            {
                return NotFound();
            }

            existingFilm.Name = film.Name;
            existingFilm.Description = film.Description;
            existingFilm.Price = film.Price;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            films.Remove(film);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            return View(film);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TP_MODUL10_103022400046.Models;

namespace TP_MODUL10_103022400046.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private static List<Film> _filmList = new List<Film>
        {
            new Film { Judul = "Inception", Sutradara = "Christopher Nolan", Tahun = "2010", Genre = "Sci-Fi", Rating = "9.0" },
            new Film { Judul = "Interstellar", Sutradara = "Christopher Nolan", Tahun = "2014", Genre = "Sci-Fi", Rating = "8.7" },
            new Film { Judul = "Parasite", Sutradara = "Bong Joon-ho", Tahun = "2019", Genre = "Thriller", Rating = "8.6" }
        };

        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return _filmList;
        }

        [HttpGet("{id}")]
        public ActionResult<Film> Get(int id)
        {
            if (id < 0 || id >= _filmList.Count)
            {
                return NotFound("Index film tidak ditemukan.");
            }
            return _filmList[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] Film newFilm)
        {
            _filmList.Add(newFilm);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= _filmList.Count)
            {
                return NotFound("Index film tidak ditemukan.");
            }
            _filmList.RemoveAt(id);
            return Ok();
        }
    }
}
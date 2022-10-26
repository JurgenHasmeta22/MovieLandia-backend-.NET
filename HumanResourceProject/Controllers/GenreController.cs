using Domain.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieLandia.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GenreController : ControllerBase
    {
        private readonly IGenreDomain _genreDomain;
        
        public GenreController(IGenreDomain genreDomain)
        {
            _genreDomain = genreDomain;
        }

        [HttpGet]
        [Route("getAllGenres")]
        public IActionResult GetAllGenres()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var genres = _genreDomain.GetAllGenres();

                if (genres != null)
                {
                    return Ok(genres);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("getGenreById/{id}")]
        public IActionResult GetGenreById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var genre = _genreDomain.GetGenreById(id);

                if (genre != null)
                    return Ok(genre);

                return NotFound();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

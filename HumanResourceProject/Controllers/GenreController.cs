using Domain.Contracts;
using DTO.MovieDTO;
using Microsoft.AspNetCore.Mvc;

namespace GenreLandia.Controllers
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

        [HttpPut]
        [Route("UpdateGenreById/{id}")]
        public IActionResult UpdateGenreByIdPut([FromRoute] int id, GenrePostDTO genre)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _genreDomain.UpdateGenreByIdPut(id, genre);
                return NoContent();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteGenreById/{id}")]
        public IActionResult DeleteGenreById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _genreDomain.DeleteGenreById(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddGenre")]
        public IActionResult AddGenre([FromBody] GenrePostDTO genre)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (genre is null)
                    return BadRequest("GenrePostDTO object is null");

                var createdGenre = _genreDomain.AddGenre(genre);
                return Ok(createdGenre);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}

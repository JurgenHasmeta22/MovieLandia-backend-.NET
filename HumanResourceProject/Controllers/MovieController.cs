using Domain.Contracts;
using DTO.MovieDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MovieLandia.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieDomain _movieDomain;

        public MovieController(IMovieDomain movieDomain)
        {
            _movieDomain = movieDomain;
        }

        [HttpGet]
        [Route("getAllMovies")]
        public IActionResult GetAllMovies([FromQuery] MovieParameters movieParameters)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var moviesPaginated = _movieDomain.GetAllMovies(movieParameters);
                /* var metadata = new
                {
                    moviesPaginated.TotalCount,
                    moviesPaginated.PageSize,
                    moviesPaginated.CurrentPage,
                    moviesPaginated.TotalPages,
                    moviesPaginated.HasNext,
                    moviesPaginated.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
                */
                if (moviesPaginated != null)
                {
                    return Ok(moviesPaginated);
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
        [Route("getMovieById/{id}")]
        public IActionResult GetMovieById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var movie = _movieDomain.GetMovieById(id);

                if (movie != null)
                    return Ok(movie);

                return NotFound();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* [HttpPatch]
        [Route("UpdateMovieById/{id}")]
        public IActionResult UpdateMovieByIdPatch([FromRoute] int id, JsonPatchDocument patchDoc)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _movieDomain.UpdateMovieByIdPatch(id, patchDoc);
                return NoContent();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        */

        [HttpPut]
        [Route("UpdateMovieById/{id}")]
        public IActionResult UpdateMovieByIdPut([FromRoute] int id, MoviePostDTO movie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _movieDomain.UpdateMovieByIdPut(id, movie);
                return NoContent();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteMovieById/{id}")]
        public IActionResult DeleteMovieById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _movieDomain.DeleteMovieById(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddMovie")]
        public IActionResult AddMovie([FromBody] MoviePostDTO movie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (movie is null)
                    return BadRequest("MoviePostDTO object is null");

                var createdMovie = _movieDomain.AddMovie(movie);
                return Ok(createdMovie);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}

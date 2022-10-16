using Domain.Contracts;
using DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;


namespace MovieLandia.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesDomain _moviesDomain;

        public MoviesController(IMoviesDomain moviesDomain)
        {
            _moviesDomain = moviesDomain;
        }


        [HttpGet]
        [Route("getAllMovies")]
        public IActionResult GetAllMovies()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var movies = _moviesDomain.GetAllMovies();

                if (movies != null)
                {
                    return Ok(movies);
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


    }

}

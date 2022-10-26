using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MovieLandia.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeDomain _episodeDomain;
        
        public EpisodeController(IEpisodeDomain episodeDomain)
        {
            _episodeDomain = episodeDomain;
        }

        [HttpGet]
        [Route("getAllEpisodes")]
        public IActionResult GetAllEpisodes()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var episodes = _episodeDomain.GetAllEpisodes();

                if (episodes != null)
                {
                    return Ok(episodes);
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
        [Route("getEpisodeById/{id}")]
        public IActionResult GetEpisodeById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var episode = _episodeDomain.GetEpisodeById(id);

                if (episode != null)
                    return Ok(episode);

                return NotFound();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

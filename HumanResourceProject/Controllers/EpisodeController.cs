using Domain.Contracts;
using DTO.MovieDTO;
using Microsoft.AspNetCore.Mvc;

namespace EpisodeLandia.Controllers
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

        [HttpPut]
        [Route("UpdateEpisodeById/{id}")]
        public IActionResult UpdateEpisodeByIdPut([FromRoute] int id, EpisodePostDTO episode)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _episodeDomain.UpdateEpisodeByIdPut(id, episode);
                return NoContent();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteEpisodeById/{id}")]
        public IActionResult DeleteEpisodeById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _episodeDomain.DeleteEpisodeById(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddEpisode")]
        public IActionResult AddEpisode([FromBody] EpisodePostDTO episode)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (episode is null)
                    return BadRequest("EpisodePostDTO object is null");

                var createdEpisode = _episodeDomain.AddEpisode(episode);
                return Ok(createdEpisode);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}

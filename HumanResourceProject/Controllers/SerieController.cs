using Domain.Contracts;
using DTO.MovieDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace SerieLandia.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SerieController : ControllerBase
    {
        private readonly ISerieDomain _serieDomain;

        public SerieController(ISerieDomain serieDomain)
        {
            _serieDomain = serieDomain;
        }

        [HttpGet]
        [Route("getAllSeries")]
        public IActionResult GetAllSeries()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var series = _serieDomain.GetAllSeries();

                if (series != null)
                {
                    return Ok(series);
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
        [Route("getSerieById/{id}")]
        public IActionResult GetSerieById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var serie = _serieDomain.GetSerieById(id);

                if (serie != null)
                    return Ok(serie);

                return NotFound();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateSerieById/{id}")]
        public IActionResult UpdateSerieByIdPut([FromRoute] int id, SeriePostDTO serie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _serieDomain.UpdateSerieByIdPut(id, serie);
                return NoContent();
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteSerieById/{id}")]
        public IActionResult DeleteSerieById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _serieDomain.DeleteSerieById(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddSerie")]
        public IActionResult AddSerie([FromBody] SeriePostDTO serie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (serie is null)
                    return BadRequest("SeriePostDTO object is null");

                var createdSerie = _serieDomain.AddSerie(serie);
                return Ok(createdSerie);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}

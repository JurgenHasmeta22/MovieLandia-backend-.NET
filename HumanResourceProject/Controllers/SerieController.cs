using Domain.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieLandia.Controllers
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
    }
}

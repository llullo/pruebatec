using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prueba.Services;
using System.Threading.Tasks;
using System;
using prueba.Models;

namespace prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElementController : ControllerBase
    {
        private readonly ILogger<QueueController> _logger;
        private IElementService _elementService;

        public ElementController(ILogger<QueueController> logger, IElementService elementRepository)
        {
            _logger = logger;
            _elementService = elementRepository;
        }

        [HttpGet("GetElements")]
        public async Task<ActionResult> GetElements()
        {
            try
            {
                return Ok(_elementService.GetElements());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetElementById/{Id}")]
        public async Task<ActionResult> GetElementById(int id)
        {
            try
            {
                return Ok(_elementService.GetElementById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetElementsByQueueId/{Id}")]
        public async Task<ActionResult> GetElementsByQueueId(int id)
        {
            try
            {
                return Ok(_elementService.GetElementsByQueueId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //esta llamada nos sirve para pintar en el front las colas
        [HttpGet("GetRemainingElementsByQueueId/{Id}")]
        public async Task<ActionResult> GetRemainingElementsByQueueId(int id)
        {
            try
            {
                return Ok(_elementService.GetRemainingsElements(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateElement(ElementDTO elementDTO)
        {
            try
            {
                //aquí realizaremos la lógica de la implementación del gestor de colas
                _elementService.CreateElement(elementDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateElement(ElementDTO elementDTO)
        {
            try
            {
                _elementService.UpdateElement(elementDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteElement(ElementDTO elementDTO)
        {
            try
            {
                _elementService.DeleteElement(elementDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

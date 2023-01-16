using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using prueba.Models;
using prueba.Repositories;
using prueba.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueueController : ControllerBase
    {      
        private readonly ILogger<QueueController> _logger;
        private IQueueService _queueService;
        private IElementService _elementRepository;
        
        public QueueController(ILogger<QueueController> logger, IQueueService queueService)
        {
            _logger = logger;
            _queueService = queueService;
        }

        [HttpGet("GetQueues")]
        public async Task<ActionResult> GetQueues()
        {
            try
            {
                return Ok(_queueService.GetQueues());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetQueueById/{Id}")]
        public async Task<ActionResult> GetQueueById(int id)
        {
            try
            {
                return Ok(_queueService.GetQueueById(id));
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
                return Ok(_elementRepository.GetElementsByQueueId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using prueba.Models;
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
        
        public QueueController(ILogger<QueueController> logger, IQueueService queueService)
        {
            _logger = logger;
            _queueService = queueService;
        }

        [HttpGet]
        public async Task<ActionResult> GetQueues()
        {
            try
            {
                return Ok(_queueService.GetQueueById(1));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

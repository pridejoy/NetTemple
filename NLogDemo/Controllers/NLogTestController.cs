using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLogDemo.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NLogTestController : ControllerBase
    {
        private readonly ILogger<NLogTestController> _logger;

        public NLogTestController(ILogger<NLogTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogError("这是错误信息");
            _logger.LogDebug("这是调试信息");
            _logger.LogInformation("这是提示信息");

            return Ok();
        }
    }
}

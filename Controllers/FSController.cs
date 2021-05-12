using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend_test.Controllers
{
    [ApiController]
    [Route("")]
    public class FSController : ControllerBase
    {
        private readonly ILogger<FSController> _logger;

        public FSController(ILogger<FSController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> GetFiles([FromQuery] string p, [FromQuery] List<string> flags)
        {
            return null;
        }

        [HttpPost]
        public string CreateFsObject([FromQuery] string p)
        {
            return null;
        }


        [HttpPost("modify")]
        public string ModifyFsObject([FromQuery] string p)
        {
            return null;
        }

        [HttpDelete]
        public string DeleteFsObject([FromQuery] string p)
        {
            return null;
        }

        [HttpGet("content")]
        public string GetFsContent([FromQuery] string p)
        {
            return null;
        }
    }
}
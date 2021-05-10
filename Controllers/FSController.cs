using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_test.FS;
using backend_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend_test.Controllers
{
    [ApiController]
    [Route("home")]
    public class FSController : ControllerBase
    {
        private readonly ILogger<FSController> _logger;
        private readonly FileSystem _fileSystem;
        public FSController(ILogger<FSController> logger, FileSystem fileSystem)
        {
            _logger = logger;
            _fileSystem = fileSystem;
        }

        [HttpGet]
        //TODO: return the list of files and directory from the current path.
        public IEnumerable<string> GetFiles([FromQuery]string p, [FromQuery]List<string> flags)
        {
            return _fileSystem.ListFsEntry(p);
        }

        [HttpPost]
        //TODO: create a FS object.
        public string CreateFsObject([FromQuery]string p, [FromBody] CreateEntry entry)
        {
            return _fileSystem.CreateFsEntry(p, entry);
        }
    }
}
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
    [Route("")]
    public class FSController : ControllerBase
    {
        private readonly ILogger<FSController> _logger;
        private readonly Directory _root;

        public FSController(ILogger<FSController> logger, Directory root)
        {
            _logger = logger;
            _root = root;
        }

        [HttpGet]
        public List<Entry> GetFiles([FromQuery] string p, [FromQuery] List<string> flags)
        {
            return _root.ListFsEntry(p);
        }

        [HttpPost]
        public Entry CreateFsObject([FromQuery] string p, CreateEntry entry)
        {
            return _root.CreateEntry(p, entry);
        }


        [HttpPost("modify")]
        public Entry ModifyFsObject([FromQuery] string p, CreateEntry entry)
        {
            return _root.ModifyEntry(p, entry);
        }

        [HttpDelete]
        public Entry DeleteFsObject([FromQuery] string p, CreateEntry entry)
        {
            return _root.DeleteEntry(p);
        }

        [HttpGet("content")]
        public string GetFsContent([FromQuery] string p)
        {
            return _root.GetEntryContent(p);
        }
    }
}
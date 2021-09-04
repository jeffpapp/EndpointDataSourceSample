using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointDataSourceSample.Controllers
{
    [Route("Test")]
    public class TestController : Controller
    {
        [HttpGet, Route("{id}", Name = "TestAction")]
        public IActionResult Index(Guid id)
        {
            var endpoint = HttpContext.GetEndpoint();

            return Ok();
        }
    }
}
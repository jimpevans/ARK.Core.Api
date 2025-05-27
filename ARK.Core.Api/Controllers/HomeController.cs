using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ARK.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to ARK Core API!");
        }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            return Ok("API is healthy!");
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok(new { Status = "Running", Timestamp = DateTime.UtcNow });
        }
    }
}

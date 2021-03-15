using Microsoft.AspNetCore.Mvc;

namespace CodingTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API Started");
        }
    }
}

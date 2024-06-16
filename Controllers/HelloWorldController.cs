using Microsoft.AspNetCore.Mvc;
using webapi;

namespace NetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService helloWorldService;
        TareasContext _DbContext;
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger, TareasContext DbContext)
        {
            _logger = logger;
            helloWorldService = helloWorld;
            _DbContext = DbContext;
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            _DbContext.Database.EnsureCreated();
            return Ok();
        }

        [HttpGet]
        [Route("Get/HelloWorld")]
        [Route("[action]")]
        public IActionResult Get()
        {
            _logger.LogInformation("Returns the message");
            return Ok(helloWorldService.GetHelloWorld());
        }
    }

}

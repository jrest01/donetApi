using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        helloWorldService = helloWorld;
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
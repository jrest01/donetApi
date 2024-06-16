using Microsoft.AspNetCore.Mvc;
using webapi.Models;


[ApiController]
[Route("api/controller")]
public class TareaController : ControllerBase
{
    private readonly ITareaServices _tareasServices;

    public TareaController(ITareaServices services)
    {
        _tareasServices = services;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_tareasServices.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        _tareasServices.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        _tareasServices.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _tareasServices.Delete(id);
        return Ok();
    }

}
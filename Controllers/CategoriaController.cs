using Microsoft.AspNetCore.Mvc;
using webapi.Models;


[ApiController]
[Route("api/controller")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaServices _categoriaServices;

    public CategoriaController(ICategoriaServices service)
    {
        _categoriaServices = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_categoriaServices.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        _categoriaServices.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        _categoriaServices.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _categoriaServices.Delete(id);
        return Ok();
    }
}
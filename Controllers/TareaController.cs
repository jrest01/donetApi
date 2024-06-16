using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace NetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        ITareaServices _tareasServices;

        public TareaController(ITareaServices service)
        {
            _tareasServices = service;
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

        [HttpPut]
        [Route("{id}")]
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
}


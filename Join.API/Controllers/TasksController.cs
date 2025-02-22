using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Join.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {

        }
    }
}

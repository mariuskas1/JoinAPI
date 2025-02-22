using AutoMapper;
using Join.API.Models.DTOs;
using Join.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Join.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository taskRepository;
        private readonly IMapper mapper;

        public TasksController(ITaskRepository taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasksDomain = await taskRepository.GetAllAsync();

            var tasksDTO = mapper.Map<List<TaskDTO>>(tasksDomain);

            return Ok(tasksDTO);
        }
    }
}

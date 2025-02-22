using AutoMapper;
using Join.API.Models.Domain;
using Join.API.Models.DTOs;
using Join.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task = Join.API.Models.Domain.Task;

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

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var taskDomain = await taskRepository.GetByIdAsync(id);

            if (taskDomain == null)
            {
                return NotFound();
            }

            var taskDTO = mapper.Map<TaskDTO>(taskDomain);
            return Ok(taskDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTaskRequestDTO addTaskRequestDTO) 
        {
            var taskDomainModel = mapper.Map<Task>(addTaskRequestDTO);
            taskDomainModel = await taskRepository.CreateAsync(taskDomainModel);
            var taskDTO = mapper.Map<TaskDTO>(taskDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = taskDTO.Id }, taskDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTaskRequestDTO updateTaskRequestDTO)
        {
            var taskDomainModel = mapper.Map<Task>(updateTaskRequestDTO);
            taskDomainModel = await taskRepository.UpdateAsync(id, taskDomainModel);
            
            if (taskDomainModel == null)
            {
                return NotFound();
            }

            var taskDTO = mapper.Map<TaskDTO>(taskDomainModel);
            return Ok(taskDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var taskDomainModel = await taskRepository.DeleteAsync(id);
            if (taskDomainModel == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }   
}

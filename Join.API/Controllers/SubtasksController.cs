using AutoMapper;
using Join.API.Models.Domain;
using Join.API.Models.DTOs;
using Join.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Join.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubtasksController : ControllerBase
    {
        private readonly ISubtaskRepository subtaskRepository;
        private readonly IMapper mapper;

        public SubtasksController(ISubtaskRepository subtaskRepository, IMapper mapper)
        {
            this.subtaskRepository = subtaskRepository;
            this.mapper = mapper;
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSubtaskDTO updateSubtaskDTO)
        {
            var subtaskDomainModel = mapper.Map<Subtask>(updateSubtaskDTO);
            subtaskDomainModel = await subtaskRepository.UpdateAsync(id, subtaskDomainModel);

            if(subtaskDomainModel == null)
            {
                return NotFound();
            }

            var subtaskDTO = mapper.Map<SubtaskDTO>(subtaskDomainModel);
            return Ok(subtaskDTO);
        }

    }
}

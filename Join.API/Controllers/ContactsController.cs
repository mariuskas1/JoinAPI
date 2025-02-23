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
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository contactRepository;
        private readonly IMapper mapper;

        public ContactsController(IContactRepository contactRepository, IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contactsDomain = await contactRepository.GetAllAsync();
            var contactDTO = mapper.Map<List<ContactDTO>>(contactsDomain);
            return Ok(contactDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var contactDomain = await contactRepository.GetByIdAsync(id);
            if (contactDomain == null)
            {
                return NotFound();
            }

            var contactDTO = mapper.Map<ContactDTO>(contactDomain);
            return Ok(contactDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddContactRequestDTO addContactRequestDTO)
        {
            var contactDomainModel = mapper.Map<Contact>(addContactRequestDTO);
            contactDomainModel = await contactRepository.CreateAsync(contactDomainModel);
            var contactDTO = mapper.Map<ContactDTO>(contactDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = contactDTO.Id }, contactDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateContactRequestDTO updateContactRequestDTO )
        {
            var contactDomainModel = mapper.Map<Contact>(updateContactRequestDTO);
            contactDomainModel = await contactRepository.UpdateAsync(id, contactDomainModel);

            if (contactDomainModel == null)
            {
                return NotFound();
            }

            var contactDTO = mapper.Map<ContactDTO>(contactDomainModel);
            return Ok(contactDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var ContactDomainModel = await contactRepository.DeleteAsync(id);
            if (ContactDomainModel == null)
            {
                return NotFound();
            }
            return Ok();
        }


    }
}

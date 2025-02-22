using AutoMapper;
using Join.API.Models.Domain;
using Join.API.Models.DTOs;
using Task = Join.API.Models.Domain.Task;

namespace Join.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TaskDTO, Task>().ReverseMap();
            CreateMap<SubtaskDTO, Subtask>().ReverseMap();
            CreateMap<ContactDTO, Contact>().ReverseMap();
        }
    }
}

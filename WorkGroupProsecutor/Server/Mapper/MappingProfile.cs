using AutoMapper;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Appeal.DTO;

namespace WorkGroupProsecutor.Server.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<RedirectedAppealModel, RedirectedAppealModelDTO>().ReverseMap();

            CreateMap<SatisfiedAppealModel, SatisfiedAppealModelDTO>().ReverseMap();            
            
            CreateMap<NoSolutionAppealModel, NoSolutionAppealModelDTO>().ReverseMap();
        }
    }
}

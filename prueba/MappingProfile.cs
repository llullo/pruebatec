using AutoMapper;
using Entities.Models;
using Entities.Models;
using prueba.Models;

namespace prueba
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Queue, QueueDTO>().ForMember(dest => dest.Elements,opt => opt.Ignore());
            CreateMap<QueueDTO, Queue>();

            CreateMap<Element, ElementDTO>();
            CreateMap<ElementDTO, Element>();
        }
    }
}

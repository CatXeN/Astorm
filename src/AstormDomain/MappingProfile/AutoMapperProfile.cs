using AstormDomain.Models.Entities;
using AstormDomain.Models.Informations;
using AutoMapper;

namespace AstormDomain.MappingProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Canal, CanalInformation>().ReverseMap();
            CreateMap<CanalMessage, CanalMessageInformation>().ReverseMap();
            CreateMap<Message, MessageInformation>().ReverseMap();
            CreateMap<Server, ServerInformation>().ReverseMap();
            CreateMap<User, UserInformation>().ReverseMap();
            CreateMap<UserMessage, UserMessageInformation>();
        }
    }
}
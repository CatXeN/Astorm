using AstormDomain.Models.Entities;
using AstormDomain.Models.Information;
using AutoMapper;

namespace AstormDomain.MappingProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Channel, ChannelInformation>().ReverseMap();
            CreateMap<ChannelMessage, ChannelMessageInformation>().ReverseMap();
            CreateMap<Server, ServerInformation>().ReverseMap();
            CreateMap<User, UserInformation>().ReverseMap();
            CreateMap<UserMessage, UserMessageInformation>();
        }
    }
}
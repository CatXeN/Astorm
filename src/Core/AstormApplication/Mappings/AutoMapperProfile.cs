using AstormApplication.DTOs;
using AstormDomain.Entities;
using AutoMapper;

namespace AstormApplication.Mappings
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
            CreateMap<FriendOfUser, FriendOfUserInformation>().ReverseMap();
        }
    }
}
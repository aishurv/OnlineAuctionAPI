using AutoMapper;
using OnlineAuctionAPI.Models;
using OnlineAuctionAPI.DTO;
namespace OnlineAuctionAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateUserDTO, User>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ;
        }
    }
}

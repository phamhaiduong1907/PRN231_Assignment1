using Ass1Server.Models.Member;
using AutoMapper;
using BusinessObject.Models;

namespace Ass1Server.Configurations
{
    public class MemberMapper : Profile
    {
        public MemberMapper() 
        {
            CreateMap<Member, MemberInfoDTO>().ReverseMap();
        }
    }
}

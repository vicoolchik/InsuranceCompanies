using AutoMapper;
using DAL.Models;
using DTO;

namespace DAL.Profiles
{
    public class PolicyProfile : Profile
    {
        public PolicyProfile()
        {
            CreateMap<Policy, PolicyDTO>().ReverseMap();
        }
    }
}

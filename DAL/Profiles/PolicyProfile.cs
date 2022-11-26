using AutoMapper;
using DAL.Models;
using DTO;
using System.Linq;

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

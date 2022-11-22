using AutoMapper;
using DAL.Models;
using DTO;

namespace DAL.Profiles
{
    public class CompanyProfile: Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
        }
    }
}

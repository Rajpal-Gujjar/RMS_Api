using AutoMapper;
using RMSApi.Common.DTO;
using RMSApi.Data.Models;

namespace RMSApi.Business.AutoMapper
{
    public class RMSProfile : Profile
    {
        public RMSProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<JobApplied, JobAppliedDTO>().ReverseMap();
            CreateMap<JobPost, JobPostDTO>().ReverseMap();
            CreateMap<JobSeeker, JobSeekerDTO>().ReverseMap();
        }
    }
}

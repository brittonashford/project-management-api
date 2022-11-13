using AutoMapper;
using project_management_api.DTOs.Issue;

namespace project_management_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Issue, GetIssueDTO>();
        }
    }
}

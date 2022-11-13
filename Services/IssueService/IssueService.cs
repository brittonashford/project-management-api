using AutoMapper;
using project_management_api.DTOs.Issue;
using project_management_api.Models;

namespace project_management_api.Services.IssueService
{
    public class IssueService : IIssueService
    {
        private static List<Issue> issues = new List<Issue>
        {
            new Issue()
            {
                IssueId = 1,
                Title = "Test Issue",
                Type = IssueType.Bug,
                Priority = IssuePriority.Low,
                Description = "I found a minor bug. plz fix?"
            },
            new Issue()
            {
                IssueId = 2,
                Title = "User Story",
                Type = IssueType.UserStory,
                Priority = IssuePriority.Medium,
                Description = "As a business user I would like to see this additional functionality."
            }
        };

        private readonly IMapper _mapper;

        public IssueService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> AddIssue(AddIssueDTO issue)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            issues.Add(_mapper.Map<Issue>(issue));
            serviceResponse.Data = issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> DeleteIssue(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            issues.Remove(issues.FirstOrDefault(i => i.IssueId == id));
            serviceResponse.Data = issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetIssueDTO>> GetIssueById(int id)
        {
            var serviceResponse = new ServiceResponse<GetIssueDTO>();
            var issue = issues.FirstOrDefault(i => i.IssueId == id);
            serviceResponse.Data = _mapper.Map<GetIssueDTO>(issue);      

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetIssues()
        {
            return new ServiceResponse<List<GetIssueDTO>> 
                { Data = issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList() };
        }

 
    }
}

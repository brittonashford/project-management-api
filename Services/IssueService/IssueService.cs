using AutoMapper;
using Azure;
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

        public async Task<ServiceResponse<List<GetIssueDTO>>> AddIssue(AddIssueDTO newIssue)
        {
            var serviceResponse = new ServiceResponse<List<GetIssueDTO>>();
            Issue issue = _mapper.Map<Issue>(newIssue);
            issue.IssueId = issues.Max(i => i.IssueId) + 1;
            issues.Add(issue);
            serviceResponse.Data = issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> DeleteIssue(int id)
        {
            ServiceResponse<List<GetIssueDTO>> response = new ServiceResponse<List<GetIssueDTO>>();

            try
            {
                Issue issue = issues.First(i => i.IssueId == id);
                issues.Remove(issue);
                response.Data = issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
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

        public async Task<ServiceResponse<GetIssueDTO>> UpdateIssue(UpdateIssueDTO updatedIssue)
        {
            ServiceResponse<GetIssueDTO> response = new ServiceResponse<GetIssueDTO>();

            try
            {
                Issue issue = issues.FirstOrDefault(i => i.IssueId == updatedIssue.IssueId);

                _mapper.Map(updatedIssue, issue);
                response.Data = _mapper.Map<GetIssueDTO>(issue);
                // ^^^ instead of setting each property manually, e.g., issue.Title  = updatedIssue.Title
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

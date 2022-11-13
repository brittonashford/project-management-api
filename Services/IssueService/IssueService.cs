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

        public async Task<ServiceResponse<List<Issue>>> AddIssue(Issue issue)
        {
            var serviceResponse = new ServiceResponse<List<Issue>>();
            issues.Add(issue);
            serviceResponse.Data = issues;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Issue>>> DeleteIssue(int id)
        {
            var serviceResponse = new ServiceResponse<List<Issue>>();
            issues.Remove(issues.FirstOrDefault(i => i.IssueId == id));
            serviceResponse.Data = issues;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Issue>> GetIssueById(int id)
        {
            var serviceResponse = new ServiceResponse<Issue>();
            serviceResponse.Data = issues.FirstOrDefault(i => i.IssueId == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Issue>>> GetIssues()
        {
            return new ServiceResponse<List<Issue>> { Data = issues };
        }

 
    }
}

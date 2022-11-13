using project_management_api.Models;

namespace project_management_api.Services.IssueService
{
    public interface IIssueService
    {
        Task<ServiceResponse<List<Issue>>> GetIssues();
        Task<ServiceResponse<Issue>> GetIssueById(int id);
        Task<ServiceResponse<List<Issue>>> AddIssue(Issue issue);
        //Task<List<Issue>> EditIssue(Issue issue);
        Task<ServiceResponse<List<Issue>>> DeleteIssue(int id);
    }
}

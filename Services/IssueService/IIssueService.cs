using project_management_api.DTOs.Issue;
using project_management_api.Models;

namespace project_management_api.Services.IssueService
{
    public interface IIssueService
    {
        Task<ServiceResponse<List<GetIssueDTO>>> GetIssues();
        Task<ServiceResponse<List<GetIssueDTO>>> GetUserIssues(int userId);
        Task<ServiceResponse<GetIssueDTO>> GetIssueById(int issueId);
        Task<ServiceResponse<List<GetIssueDTO>>> AddIssue(AddIssueDTO issue);
        Task<ServiceResponse<GetIssueDTO>> UpdateIssue(UpdateIssueDTO issue);
        Task<ServiceResponse<List<GetIssueDTO>>> DeleteIssue(int issueId);
    }
}

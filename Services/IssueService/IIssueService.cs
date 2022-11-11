namespace project_management_api.Services.IssueService
{
    public interface IIssueService
    {
        List<Issue> GetIssues();
        Issue GetIssueById(int id);
        List<Issue> AddIssue(Issue issue);
        //List<Issue> EditIssue(Issue issue);
        List<Issue> DeleteIssue(int id);
    }
}

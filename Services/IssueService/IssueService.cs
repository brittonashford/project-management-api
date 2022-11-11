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

        public List<Issue> AddIssue(Issue issue)
        {
            issues.Add(issue);
            return issues;
        }

        public List<Issue> DeleteIssue(int id)
        {
            issues.Remove(issues.FirstOrDefault(i => i.IssueId == id));
            return issues;
        }

        public Issue GetIssueById(int id)
        {
            return issues.FirstOrDefault(i => i.IssueId == id);
        }

        public List<Issue> GetIssues()
        {
            return issues;
        }

 
    }
}

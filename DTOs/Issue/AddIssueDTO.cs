using project_management_api.Models;

namespace project_management_api.DTOs.Issue
{
    public class AddIssueDTO
    {
        public string Title { get; set; } = string.Empty;
        public IssueType Type { get; set; }
        public IssuePriority Priority { get; set; } = IssuePriority.None;
        public IssueStatus Status { get; set; } = IssueStatus.NotStarted;
        //public Sprint? SprintAssignment { get; set; }
        //public Developer? DeveloperAssignment { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

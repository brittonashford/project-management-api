namespace project_management_app_api.Models
{
    public class Issue
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Priority? TaskPriority { get; set; } = Priority.None;
        //public Sprint? SprintAssignment { get; set; }
        //public Developer? DeveloperAssignment { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace project_management_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IssueType
    {
        UserStory,
        Bug,
        Task
    }
}

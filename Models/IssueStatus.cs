using System.Text.Json.Serialization;

namespace project_management_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IssueStatus
    {
        NotStarted,
        Development,
        Testing,
        FailedTesting,
        ReadyToDeploy,
        Complete
    }
}

using System.Text.Json.Serialization;

namespace project_management_app_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IssuePriority
    {
        None = 0,
        High = 1,
        Medium = 2,
        Low = 3
    }
}

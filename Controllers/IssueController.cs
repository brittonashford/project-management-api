using Microsoft.AspNetCore.Mvc;

namespace project_management_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase
    {
        private static Issue issue = new Issue()
        {
            TaskId = 1,
            Title = "Test Issue",
            Description = "I found a minor bug. plz fix?"
        };

        [HttpGet]
        public IActionResult GetIssues()
        {
            return Ok(issue);
        }
    }
}

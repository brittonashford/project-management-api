using Microsoft.AspNetCore.Mvc;
using project_management_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using project_management_app_api.Models;
using project_management_api.Services.IssueService;

namespace project_management_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpGet("GetIssues")]
        public async Task<ActionResult<ServiceResponse<List<Issue>>>> GetIssues()
        {
            return Ok(await _issueService.GetIssues());
        }

        [HttpGet("GetIssueById/{id}")]
        public async Task<ActionResult<ServiceResponse<Issue>>> GetIssueById(int id)
        {
            return Ok(await _issueService.GetIssueById(id));
        }

        [HttpPost("AddIssue")]
        public async Task<ActionResult<ServiceResponse<List<Issue>>>> AddIssue(Issue issue)
        {
            return Ok(await _issueService.AddIssue(issue));
        }

        //[HttpPut("EditIssue/{id}")]
        //public ActionResult<Issue> EditIssue(Issue issue)
        //{

        //    var issueToEdit = issues.FirstOrDefault(i => i.IssueId == issue.IssueId);
        //    issueToEdit.IssueId = issue.IssueId;
        //    issueToEdit.Title = issue.Title;    
        //    issueToEdit.Type = issue.Type;  
        //    issueToEdit.Priority = issue.Priority;
        //    issueToEdit.Status = issue.Status;
        //    issueToEdit.Description = issue.Description;    

        //    return Ok(issueToEdit);
        //}

        [HttpDelete("DeleteIssue/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Issue>>>> DeleteIssue(int id)
        {            
            return Ok(_issueService.DeleteIssue(id));
        }
    }
}

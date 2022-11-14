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
using project_management_api.DTOs.Issue;

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
        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> GetIssues()
        {
            return Ok(await _issueService.GetIssues());
        }

        [HttpGet("GetIssueById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetIssueDTO>>> GetIssueById(int id)
        {
            return Ok(await _issueService.GetIssueById(id));
        }

        [HttpPost("AddIssue")]
        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> AddIssue(AddIssueDTO newIssue)
        {
            return Ok(await _issueService.AddIssue(newIssue));
        }

        [HttpPut("UpdateIssue/{id}")]
        public async Task<ActionResult<ServiceResponse<GetIssueDTO>>> UpdateIssue(UpdateIssueDTO updatedIssue)
        {
            var response = await _issueService.UpdateIssue(updatedIssue);   

            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("DeleteIssue/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> DeleteIssue(int id)
        {
            var response = await _issueService.DeleteIssue(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}

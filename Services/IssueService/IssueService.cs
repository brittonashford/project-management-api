using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using project_management_api.Data;
using project_management_api.DTOs.Issue;
using project_management_api.Models;

namespace project_management_api.Services.IssueService
{
    public class IssueService : IIssueService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public IssueService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> AddIssue(AddIssueDTO newIssue)
        {
            var response = new ServiceResponse<List<GetIssueDTO>>();
            Issue issue = _mapper.Map<Issue>(newIssue);
            _dataContext.Issues.Add(issue);
            await _dataContext.SaveChangesAsync();  //  <-- adds new row in database

            response.Data = await _dataContext.Issues
                .Select(i => _mapper.Map<GetIssueDTO>(i))
                .ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> DeleteIssue(int issueId)
        {
            var response = new ServiceResponse<List<GetIssueDTO>>();

            try
            {
                Issue issue = await _dataContext.Issues.FirstAsync(i => i.IssueId == issueId);
                _dataContext.Issues.Remove(issue);
                await _dataContext.SaveChangesAsync();  

                response.Data = _dataContext.Issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetIssueDTO>> GetIssueById(int issueId)
        {
            var response = new ServiceResponse<GetIssueDTO>();
            var issue = await _dataContext.Issues.FirstOrDefaultAsync(i => i.IssueId == issueId);
            response.Data = _mapper.Map<GetIssueDTO>(issue);      

            return response;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetIssues()
        {
            var response = new ServiceResponse<List<GetIssueDTO>>();
            var issues = await _dataContext.Issues.ToListAsync();
            response.Data = issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();

            return response;
        }

        public async Task<ServiceResponse<List<GetIssueDTO>>> GetUserIssues(int userId)
        {
            var response = new ServiceResponse<List<GetIssueDTO>>();
            var issues = await _dataContext.Issues
                .Where(i => i.User.UserId == userId)
                .ToListAsync();

            response.Data = issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetIssueDTO>> UpdateIssue(UpdateIssueDTO updatedIssue)
        {
            var response = new ServiceResponse<GetIssueDTO>();

            try
            {
                var issue = await _dataContext.Issues
                    .FirstOrDefaultAsync(i => i.IssueId == updatedIssue.IssueId);

                _mapper.Map(updatedIssue, issue);

                //Note: no need to call an update method for PUT method.
                //Modifying propeties (via mapper above) and calling SaveChangesAsync() is sufficient.

                await _dataContext.SaveChangesAsync();

                response.Data = _mapper.Map<GetIssueDTO>(issue);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

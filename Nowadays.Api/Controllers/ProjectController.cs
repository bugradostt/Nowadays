using Microsoft.AspNetCore.Mvc;
using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Dtos.Partner;
using Nowadays.DataAccess.Dtos.Project;

namespace Nowadays.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : CustomBaseController
    {
        IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;

        }

        [Route("get-project")]
        [HttpPost]
        public async Task<IActionResult> GetProject(RequestCompanyIdDto request)
        {
            var result = await _projectService.GetProjectAsync(request.CompanyId);
            return ActionResultInstance(result);

        }

        [Route("add-project")]
        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectDto project)
        {
            var result = await _projectService.AddProjectAsync(project);
            return ActionResultInstance(result);

        }
        
        [Route("delete-project")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProject(RequestProjectIdDto request)
        {
            var result = await _projectService.DeleteProjectAsync(request.ProjectId);
            return ActionResultInstance(result);
        }

        [Route("update-project")]
        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto project)
        {
            var result = await _projectService.UpdateProjectAsync(project);
            return ActionResultInstance(result);

        }

        [Route("assignment-employees-to-project")]
        [HttpPost]
        public async Task<IActionResult> AssignmentEmployeesToProject( AssignmentEmployeesToProjectDto assignmentEmployeesToProject)
        {
            var result = await _projectService.AssignmentEmployeesToProjectAsync(assignmentEmployeesToProject);
            return ActionResultInstance(result);

        }

        [Route("assignment-issue-to-project")]
        [HttpPost]
        public async Task<IActionResult> AssignmentIssueToProject( AssignmentIssueToProjectDto assignmentIssueToProject)
        {
            var result = await _projectService.AssignmentIssueToProjectAsync(assignmentIssueToProject);
            return ActionResultInstance(result);

        }
    }
}
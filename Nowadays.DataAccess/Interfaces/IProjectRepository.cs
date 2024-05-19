using Nowadays.DataAccess.Dtos.Project;
using Nowadays.DataAccess.Dtos.Response;

namespace Nowadays.DataAccess.Interfaces
{
    public interface IProjectRepository
    {
        Task<ResponseDto<List<GetProjectDto>>> GetProjectAsync(string companyId);
        Task<ResponseDto<NoDataDto>> AddProjectAsync(AddProjectDto project);
        Task<ResponseDto<NoDataDto>> UpdateProjectAsync(UpdateProjectDto project);
        Task<ResponseDto<NoDataDto>> DeleteProjectAsync(string projectId);
    }
}
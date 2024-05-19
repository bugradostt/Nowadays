using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Dtos.Project;
using Nowadays.DataAccess.Dtos.Response;
using Nowadays.DataAccess.Interfaces;

namespace Nowadays.Business.Implementations
{
    public class ProjectService : IProjectService
    {
        readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

        }


        public async Task<ResponseDto<NoDataDto>> AddProjectAsync(AddProjectDto project)
        {
            try
            {
                var response = await _projectRepository.AddProjectAsync(project);

                if (!response.IsSuccessful)
                {
                    // Birden fazla hata mesajını birleştirerek tek bir hata mesajı dizesine dönüştürün
                    string errorMessage = response.errors != null && response.errors.Errors.Count > 0
                        ? string.Join(Environment.NewLine, response.errors.Errors)
                        : "An error occurred";

                    return ResponseDto<NoDataDto>.Fail(errorMessage, 400, true);
                }

                return ResponseDto<NoDataDto>.Success(200);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<ResponseDto<NoDataDto>> DeleteProjectAsync(string projectId)
        {
           try
            {
                var response = await _projectRepository.DeleteProjectAsync(projectId);

                if (!response.IsSuccessful)
                {
                    // Birden fazla hata mesajını birleştirerek tek bir hata mesajı dizesine dönüştürün
                    string errorMessage = response.errors != null && response.errors.Errors.Count > 0
                        ? string.Join(Environment.NewLine, response.errors.Errors)
                        : "An error occurred";

                    return ResponseDto<NoDataDto>.Fail(errorMessage, 400, true);
                }

                return ResponseDto<NoDataDto>.Success(200);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<ResponseDto<List<GetProjectDto>>> GetProjectAsync(string companyId)
        {
            try
            {
                var response = await _projectRepository.GetProjectAsync(companyId);

                if (!response.IsSuccessful)
                {
                    // Birden fazla hata mesajını birleştirerek tek bir hata mesajı dizesine dönüştürün
                    string errorMessage = response.errors != null && response.errors.Errors.Count > 0
                        ? string.Join(Environment.NewLine, response.errors.Errors)
                        : "An error occurred";

                    return ResponseDto<List<GetProjectDto>>.Fail(errorMessage, 400, true);
                }

                return ResponseDto<List<GetProjectDto>>.Success(200);
            }
            catch (Exception ex)
            {
                return ResponseDto<List<GetProjectDto>>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<ResponseDto<NoDataDto>> UpdateProjectAsync(UpdateProjectDto project)
        {
            try
            {
                var response = await _projectRepository.UpdateProjectAsync(project);

                if (!response.IsSuccessful)
                {
                    // Birden fazla hata mesajını birleştirerek tek bir hata mesajı dizesine dönüştürün
                    string errorMessage = response.errors != null && response.errors.Errors.Count > 0
                        ? string.Join(Environment.NewLine, response.errors.Errors)
                        : "An error occurred";

                    return ResponseDto<NoDataDto>.Fail(errorMessage, 400, true);
                }

                return ResponseDto<NoDataDto>.Success(200);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoDataDto>.Fail(ex.Message, 500, true);
            }
        }

    }
}
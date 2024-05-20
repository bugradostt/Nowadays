using Nowadays.Business.Interfaces;
using Nowadays.DataAccess.Dtos.Issue;
using Nowadays.DataAccess.Dtos.Response;
using Nowadays.DataAccess.Interfaces;

namespace Nowadays.Business.Implementations
{
    public class IssueService : IIssueService
    {
        readonly IIssueRepository _ıssueRepository;
        public IssueService(IIssueRepository ıssueRepository)
        {
            _ıssueRepository = ıssueRepository;

        }

        public async Task<ResponseDto<NoDataDto>> AddIssueAsync(AddIssueDto issue)
        {
            try
            {
                var response = await _ıssueRepository.AddIssueAsync(issue);

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

        public async Task<ResponseDto<NoDataDto>> DeleteIssueAsync(string issueId)
        {
            try
            {
                var response = await _ıssueRepository.DeleteIssueAsync(issueId);

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

        public async Task<ResponseDto<List<GetIssueDto>>> GetIssueAsync(string projectId)
        {
            try
            {
                var response = await _ıssueRepository.GetIssueAsync(projectId);

                if (!response.IsSuccessful)
                {
                    // Birden fazla hata mesajını birleştirerek tek bir hata mesajı dizesine dönüştürün
                    string errorMessage = response.errors != null && response.errors.Errors.Count > 0
                        ? string.Join(Environment.NewLine, response.errors.Errors)
                        : "An error occurred";

                    return ResponseDto<List<GetIssueDto>>.Fail(errorMessage, 400, true);
                }

                return ResponseDto<List<GetIssueDto>>.Success(response.Data,200);
            }
            catch (Exception ex)
            {
                return ResponseDto<List<GetIssueDto>>.Fail(ex.Message, 500, true);
            }
        }

        public async Task<ResponseDto<NoDataDto>> UpdateIssueAsync(UpdateIssueDto issue)
        {
            try
            {
                var response = await _ıssueRepository.UpdateIssueAsync(issue);

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
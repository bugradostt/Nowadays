namespace Nowadays.DataAccess.Dtos.Response
{
    public class BoolResponseDto
    {
        public bool Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public ErrorDto? Error { get; set; }

        public static BoolResponseDto Success(bool data, int statusCode)
        {
            return new BoolResponseDto { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static BoolResponseDto Fail(ErrorDto errorDto, int statusCode)
        {
            return new BoolResponseDto { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }

        public static BoolResponseDto Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new BoolResponseDto { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}
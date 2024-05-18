namespace Nowadays.DataAccess.Dtos.Response
{
    public class ResponseDto<TEntity> where TEntity : class
    {
        public TEntity? Data { get; set; }

        public int status { get; set; }

        public bool IsSuccessful { get; set; } // kendi iç yapımızda kullanacağız.
        public ErrorDto? errors { get; set; }
        public static ResponseDto<TEntity> Success(TEntity data, int status)
        {
            return new ResponseDto<TEntity> { Data = data, status = status, IsSuccessful = true };
        }
        public static ResponseDto<TEntity> Success(int status)
        {
            return new ResponseDto<TEntity> { Data = default, status = status, IsSuccessful = true };
        }
        public static ResponseDto<TEntity> Fail(ErrorDto errorDto, int status)
        {

            return new ResponseDto<TEntity> { errors = errorDto, status = status, IsSuccessful = false };
        }
        public static ResponseDto<TEntity> Fail(string errorMessage, int status, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new ResponseDto<TEntity> { errors = errorDto, status = status, IsSuccessful = false };
        }
    }
}
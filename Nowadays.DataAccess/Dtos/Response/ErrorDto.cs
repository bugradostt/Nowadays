namespace Nowadays.DataAccess.Dtos.Response
{
    public class ErrorDto
    {
        public List<string> Errors { get; private set; } = [];  // public List<String> Errors { get; private set; } = new List<String>();  C# 9 ++
        public bool IsShow { get; private set; } // Kullanıcıya verilmesi istenen bir hata ise True yapılmalı
        public ErrorDto()
        {
            Errors = []; //Errors = new List<string>(); C# 12 ++
            IsShow = false;
        }
        public ErrorDto(string error, bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }
        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }

    }
}
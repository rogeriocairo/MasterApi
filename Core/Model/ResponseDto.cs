namespace MasterApi.Core.Model
{
    public class ResponseDto<T> where T : class
    {
        public ResponseDto(T? data, bool success = true, int statusCode = 200, string? message = "")
        {
            Data = data;
            Success = success;
            StatusCode = statusCode;
            Message = message;
        }

        public T? Data { get; set; }

        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public string? Message { get; set; }
    }
}

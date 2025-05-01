namespace PeopleFirst.Application.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public ApiResponse() { }

        public ApiResponse(T data, string? message = null)
        {
            Data = data;
            Message = message;
        }

        public ApiResponse(string message, IEnumerable<string> errors)
        {
            Success = false;
            Message = message;
            Errors = errors;
        }
    }
}

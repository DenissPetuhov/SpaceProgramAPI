namespace SpaceProgram.Model
{
    public class ApiResponse
    {
        public int code { get; set; }
        public string message { get; set; } 
        public object? ResponseData { get; set; }

    }
    public enum ResponseType
    {
        Success,
        NotFound,
        Error
    }
}

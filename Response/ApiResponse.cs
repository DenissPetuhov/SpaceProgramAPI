using SpaceProgram.Enum;

namespace SpaceProgram.Model
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        public StatusCode StatusCode { get; set; }

        public string message { get; set; }

        public T ResponseData { get; set; }
    }
    public interface IApiResponse<T>
    {
        StatusCode StatusCode { get; }
      
        T ResponseData{get;}
    }



}

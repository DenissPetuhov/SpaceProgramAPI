namespace SpaceProgram.Model
{
    public class ResponseHandler
    {
        public static ApiResponse GetExeptionResponse(Exception ex)
        {
            ApiResponse response = new ApiResponse();
            response.code = 1;
            response.message = ex.Message;
            return response;
        }

        public static ApiResponse GetApiResponse(ResponseType type, object? responseData)
        {
            ApiResponse response;
            response = new ApiResponse { ResponseData = responseData};
            switch (type)
            {
                case ResponseType.Success:
                    response.code = 0;
                    response.message = "Success";
                    break;
                case ResponseType.NotFound:
                    response.code = 2;
                    response.message = "No record";
                    break;
           
            }
            return response;

        }
    }
}

using SpaceProgram.Enum;
using SpaceProgram.Model;
using SpaceProgram.Model.Interfaces;
using SpaceProgram.Service.Intarface;

namespace SpaceProgram.Service.Implementations
{
    public class SpaceSystemService : ISpaceService<SpaceSystemModel>
    {
        private readonly IBaseRepository<SpaceSystemModel> _spaceSystemRepository;

        public SpaceSystemService(IBaseRepository<SpaceSystemModel> spaceSystemRepository)
        {
            _spaceSystemRepository = spaceSystemRepository;
        }
        public IApiResponse<SpaceSystemModel> Delete(int id)
        {
            var apiResponse = new ApiResponse<SpaceSystemModel>();
          
            try
            {
                apiResponse.StatusCode = StatusCode.Success;
                _spaceSystemRepository.Delete(id);
                apiResponse.message = "Успешно";
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.message = ex.Message;
                apiResponse.StatusCode = StatusCode.Error;
                return apiResponse;
            }
        }

        public IApiResponse<IEnumerable<SpaceSystemModel>> GetAll()
        {
            var apiResponse = new ApiResponse<IEnumerable<SpaceSystemModel>>();
            try
            {
                apiResponse.StatusCode = StatusCode.Success;
                var spaceSystem = _spaceSystemRepository.GetAll();
                if (spaceSystem.Count == 0)
                {
                    apiResponse.message = "NotFound";
                    apiResponse.StatusCode = StatusCode.NotFound;
                    return apiResponse;
                }
               
                apiResponse.ResponseData = spaceSystem;
                return apiResponse;
            }
            catch (Exception ex)
            {

                return new ApiResponse<IEnumerable<SpaceSystemModel>>() { message = ex.Message, StatusCode = StatusCode.Error };

            }
        }

        public IApiResponse<SpaceSystemModel> GetById(int id)
        {
            var apiResponse = new ApiResponse<SpaceSystemModel>();
            try
            {
                var spaceObject = _spaceSystemRepository.GetById(id);
                if (spaceObject == null)
                {
                    apiResponse.message = "NotFound";
                    apiResponse.StatusCode = StatusCode.NotFound;
                    return apiResponse;
                }
                apiResponse.StatusCode = StatusCode.Success;
                apiResponse.message = "Успешно";
                apiResponse.ResponseData = spaceObject;
                return apiResponse;
            }
            catch (Exception ex)
            {
                return new ApiResponse<SpaceSystemModel>() { message = ex.Message, StatusCode = StatusCode.Error }; ;
            }
        }

        public IApiResponse<SpaceSystemModel> PostSave(SpaceSystemModel obj)
        {
            var apiResponse = new ApiResponse<SpaceSystemModel>();
            try
            {
                _spaceSystemRepository.Save(obj);
                apiResponse.StatusCode = StatusCode.Success;
                apiResponse.message = "Успешно";
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.message = ex.Message;
                apiResponse.StatusCode = StatusCode.Error;
                return apiResponse;
            }
        }

        public IApiResponse<SpaceSystemModel> PutUpdate(SpaceSystemModel obj)
        {
            var apiResponse = new ApiResponse<SpaceSystemModel>();
            try
            {
                _spaceSystemRepository.Save(obj);
                apiResponse.StatusCode = StatusCode.Success;
                apiResponse.message = "Успешно";
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.message = ex.Message;
                apiResponse.StatusCode = StatusCode.Error;
                return apiResponse;
            }
        }
    }
}

using SpaceProgram.Enum;
using SpaceProgram.Model;
using SpaceProgram.Model.Interfaces;
using SpaceProgram.Service.Intarface;

namespace SpaceProgram.Service.Implementations
{
    public class SpaceObjectService : ISpaceObjectService
    {
        private readonly ISpaceObjetcRepository _spaceObjectRepository;

        public SpaceObjectService(ISpaceObjetcRepository spaceObjectRepository)
        {
            _spaceObjectRepository = spaceObjectRepository;
        }

        public IApiResponse<IEnumerable<SpaceObjectModel>> GetAll()
        {
            var apiResponse = new ApiResponse<IEnumerable<SpaceObjectModel>>();
            try
            {
                apiResponse.StatusCode = StatusCode.Success;
                var spaceObjects = _spaceObjectRepository.GetAll();
                if (spaceObjects.Count == 0)
                {
                    apiResponse.message = "Таблица пуста";
                    apiResponse.StatusCode = StatusCode.NotFound;
                }
               
                apiResponse.ResponseData = spaceObjects;
                return apiResponse;
            }
            catch (Exception ex)
            {

                return new ApiResponse<IEnumerable<SpaceObjectModel>>() { message = ex.Message, StatusCode = StatusCode.Error };

            }

        }
        public IApiResponse<SpaceObjectModel> GetById(int id)
        {
            var apiResponse = new ApiResponse<SpaceObjectModel>();
            try
            {
                apiResponse.StatusCode = StatusCode.Success;
                var spaceObject = _spaceObjectRepository.GetById(id);
                if (spaceObject == null)
                {
                    apiResponse.message = "NotFound";
                    apiResponse.StatusCode = StatusCode.NotFound;
                }
               
                apiResponse.ResponseData = spaceObject;
                return apiResponse;
            }
            catch (Exception ex)
            {
                return new ApiResponse<SpaceObjectModel>() { message = ex.Message, StatusCode = StatusCode.Error }; ;
            }

        }
        public IApiResponse<IEnumerable<SpaceObjectModel>> GetBySpaceSystemId(int id)
        {
            var apiResponse = new ApiResponse<IEnumerable<SpaceObjectModel>>();
            try
            {
                apiResponse.StatusCode = StatusCode.Success;
                var spaceObjects = _spaceObjectRepository.GetBySpaceSystemId(id);
                if (spaceObjects.Count == 0)
                {
                    apiResponse.message = "NotFound";
                    apiResponse.StatusCode = StatusCode.NotFound;
                }
           
                apiResponse.ResponseData = spaceObjects;
                return apiResponse;
            }
            catch (Exception ex)
            {

                return new ApiResponse<IEnumerable<SpaceObjectModel>>() { message = ex.Message, StatusCode = StatusCode.Error };

            }
        }

        public IApiResponse<SpaceObjectModel> PostSave(SpaceObjectModel obj)
        {
            var apiResponse = new ApiResponse<SpaceObjectModel>();
            try
            {
                _spaceObjectRepository.Save(obj);
                apiResponse.StatusCode = StatusCode.Success;
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.message = ex.Message;
                apiResponse.StatusCode = StatusCode.Error;
                return apiResponse;
            }
        }

        public IApiResponse<SpaceObjectModel> PutUpdate(SpaceObjectModel obj)
        {

            var apiResponse = new ApiResponse<SpaceObjectModel>();
            try
            {
                _spaceObjectRepository.Save(obj);
                apiResponse.StatusCode = StatusCode.Success;
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.message = ex.Message;
                apiResponse.StatusCode = StatusCode.Error;
                return apiResponse;
            }
        }

        public IApiResponse<SpaceObjectModel> Delete(int id)
        {
            var apiResponse = new ApiResponse<SpaceObjectModel>();
            try
            {
                _spaceObjectRepository.Delete(id);
                apiResponse.StatusCode = StatusCode.Success;
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

using Microsoft.AspNetCore.Mvc;
using SpaceProgram.EFCore;
using SpaceProgram.Model;


namespace SpaceProgram.Controllers
{

    [ApiController]
    public class SpaceController : ControllerBase
    {
        private readonly DbHelper _db;
        public SpaceController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }
        //GET
        //Object
        [HttpGet]
        [Route("api/[controller]/GetAllSpaceObjects")]
        public IActionResult GetAllSpaceObjects()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<SpaceObjectModel> data = _db.GetAllSpaceObjects();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));
            }
            catch (Exception ex)
            {

                type = ResponseType.Error;
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetSpaceObjectById/{id}")]
        public IActionResult GetSpaceObjectById(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                SpaceObjectModel data = _db.GetSpaceObjectById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));
            }
            catch (Exception ex)
            {

                type = ResponseType.Error;
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetSpaceObjectsBySpaceSystemId/{id}")]
        public IActionResult GetSpaceObjectsBySpaceSystemId(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<SpaceObjectModel> data = _db.GetSpaceObjectsBySpaceSystemId(id);

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));
            }
            catch (Exception ex)
            {

                type = ResponseType.Error;
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        //System
        [HttpGet]
        [Route("api/[controller]/GetAllSpaceSystems")]
        public IActionResult GetAllSpaceSystems()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<SpaceSystemModel> data = _db.GetAllSpaceSystems();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Error;
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetSpaceSystemById/{id}")]
        public IActionResult GetSpaceSystemById(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                SpaceSystemModel data = _db.GetSpaceSystemById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));
            }
            catch (Exception ex)
            {

                type = ResponseType.Error;
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        // POST
        //Object
        [HttpPost]
        [Route("api/[controller]/SaveSpaceObject")]
        public IActionResult PostSaveSpaceObject([FromBody] SpaceObjectModel objectModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveSpaceObject(objectModel);
                return Ok(ResponseHandler.GetApiResponse(type, objectModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));

            }
        }
        //System
        [HttpPost]
        [Route("api/[controller]/SaveSpaceSystem")]
        public IActionResult PostSaveSpaceSystem([FromBody] SpaceSystemModel systemModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveSpaceSystem(systemModel);
                return Ok(ResponseHandler.GetApiResponse(type, systemModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        //PUT 
        //Object
        [HttpPut]
        [Route("api/[controller]/UpdateSpaceObject")]
        public IActionResult PutUpdateSpaceObject([FromBody] SpaceObjectModel objectModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveSpaceObject(objectModel);
                return Ok(ResponseHandler.GetApiResponse(type, objectModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        //System
        [HttpPut]
        [Route("api/[controller]/UpdateSpaceSystem")]
        public IActionResult PutUpdateSpaceSystem([FromBody] SpaceSystemModel systemModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveSpaceSystem(systemModel);
                return Ok(ResponseHandler.GetApiResponse(type, systemModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        //DELETE 
        //Object
        [HttpDelete]
        [Route("api/[controller]/DeleteSpaceObject/{id}")]
        public IActionResult DeleteSpaceObject(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteSpaceObject(id);
                return Ok(ResponseHandler.GetApiResponse(type, "Delete Success"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        //System
        [HttpDelete]
        [Route("api/[controller]/DeleteSpaceSystem/{id}")]
        public IActionResult DeleteSpaceSystem(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteSpaceSystem(id);
                return Ok(ResponseHandler.GetApiResponse(type, "Delete Success"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
    }
}

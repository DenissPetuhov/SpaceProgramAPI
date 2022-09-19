using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpaceProgram.EFCore;
using SpaceProgram.Model;
using SpaceProgram.Model.Repositories;

namespace SpaceProgram.Controllers
{
    public class SpaceObjectController : Controller
    {
        // GET: SpaceObjectController

        private readonly SpaceObjectRepository _db;
        public SpaceObjectController(EF_DataContext eF_DataContext, IMapper mapper)

        {
            _db = new SpaceObjectRepository(eF_DataContext, mapper);

        }
        //GET
        [HttpGet]
        [Route("api/[controller]/GetAllSpaceObjects")]
        public IActionResult GetAllSpaceObjects()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<SpaceObjectModel> data = _db.GetAll();

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
                SpaceObjectModel data = _db.GetById(id);

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
                IEnumerable<SpaceObjectModel> data = _db.GetBySpaceSystemId(id);

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
        // POST
        [HttpPost]
        [Route("api/[controller]/SaveSpaceObject")]
        public IActionResult PostSaveSpaceObject([FromBody] SpaceObjectModel objectModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Save(objectModel);
                return Ok(ResponseHandler.GetApiResponse(type, objectModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));

            }
        }
        //PUT 
        [HttpPut]
        [Route("api/[controller]/UpdateSpaceObject")]
        public IActionResult PutUpdateSpaceObject([FromBody] SpaceObjectModel objectModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Save(objectModel);
                return Ok(ResponseHandler.GetApiResponse(type, objectModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        //DELETE 
        [HttpDelete]
        [Route("api/[controller]/DeleteSpaceObject/{id}")]
        public IActionResult DeleteSpaceObject(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Delete(id);
                return Ok(ResponseHandler.GetApiResponse(type, "Delete Success"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
    }
}

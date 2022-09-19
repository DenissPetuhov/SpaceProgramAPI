using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpaceProgram.EFCore;
using SpaceProgram.Model;
using SpaceProgram.Model.Repositories;

namespace SpaceProgram.Controllers
{

    [ApiController]
    public class SpaceSystemController : ControllerBase
    {
        private readonly SpaceSystemRepository _db;
        public SpaceSystemController(EF_DataContext eF_DataContext, IMapper mapper)
        {
            _db = new SpaceSystemRepository(eF_DataContext, mapper);
        }
        //GET
        [HttpGet]
        [Route("api/[controller]/GetAllSpaceSystems")]
        public IActionResult GetAllSpaceSystems()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<SpaceSystemModel> data = _db.GetAll();

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
                SpaceSystemModel data = _db.GetById(id);

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
        //POST
        [HttpPost]
        [Route("api/[controller]/SaveSpaceSystem")]
        public IActionResult PostSaveSpaceSystem([FromBody] SpaceSystemModel systemModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Save(systemModel);
                return Ok(ResponseHandler.GetApiResponse(type, systemModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        //PUT
        [HttpPut]
        [Route("api/[controller]/UpdateSpaceSystem")]
        public IActionResult PutUpdateSpaceSystem([FromBody] SpaceSystemModel systemModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Save(systemModel);
                return Ok(ResponseHandler.GetApiResponse(type, systemModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExeptionResponse(ex));
            }
        }
        //DELETE
        [HttpDelete]
        [Route("api/[controller]/DeleteSpaceSystem/{id}")]
        public IActionResult DeleteSpaceSystem(int id)
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

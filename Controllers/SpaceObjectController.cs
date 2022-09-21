using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpaceProgram.EFCore;
using SpaceProgram.Enum;
using SpaceProgram.Model;
using SpaceProgram.Model.Repositories;
using SpaceProgram.Service.Intarface;

namespace SpaceProgram.Controllers
{
    public class SpaceObjectController : Controller
    {
        // GET: SpaceObjectController

        private readonly ISpaceObjectService _spaceObjectService;

        public SpaceObjectController(ISpaceObjectService spaceObjectService)
        {
            _spaceObjectService = spaceObjectService;
        }

        //GET
        [HttpGet]
        [Route("api/[controller]/GetAllSpaceObjects")]
        public IActionResult GetAllSpaceObjects()
        {

            var response = _spaceObjectService.GetAll();
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                return base.Ok(response.ResponseData);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("api/[controller]/GetSpaceObjectById/{id}")]
        public IActionResult GetSpaceObjectById(int id)
        {
            var response = _spaceObjectService.GetById(id);
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                return base.Ok(response.ResponseData);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("api/[controller]/GetSpaceObjectsBySpaceSystemId/{id}")]
        public IActionResult GetSpaceObjectsBySpaceSystemId(int id)
        {
            var response = _spaceObjectService.GetBySpaceSystemId(id);
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                return base.Ok(response.ResponseData);

            }
            return BadRequest(response);
        }
        // POST
        [HttpPost]
        [Route("api/[controller]/SaveSpaceObject")]
        public IActionResult PostSaveSpaceObject([FromBody] SpaceObjectModel objectModel)
        {
            var response = _spaceObjectService.PostSave(objectModel);
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                return base.Ok(response);

            }
            return BadRequest(response);
        }
        //PUT 
        [HttpPut]
        [Route("api/[controller]/UpdateSpaceObject")]
        public IActionResult PutUpdateSpaceObject([FromBody] SpaceObjectModel objectModel)
        {
            var response = _spaceObjectService.PutUpdate(objectModel);
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                
                return base.Ok(response);

            }
            return BadRequest(response);
        }
        //DELETE 
        [HttpDelete]
        [Route("api/[controller]/DeleteSpaceObject/{id}")]
        public IActionResult DeleteSpaceObject(int id)
        {
            var response = _spaceObjectService.Delete(id);
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                return base.Ok(response);

            }
            return BadRequest(response);
        }
    }
}

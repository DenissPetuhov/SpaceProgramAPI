using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpaceProgram.EFCore;
using SpaceProgram.Enum;
using SpaceProgram.Model;
using SpaceProgram.Model.Repositories;
using SpaceProgram.Service.Intarface;

namespace SpaceProgram.Controllers
{

    [ApiController]
    public class SpaceSystemController : ControllerBase
    {
        private readonly ISpaceService<SpaceSystemModel> _spaceSystemService;

        public SpaceSystemController(ISpaceService<SpaceSystemModel> spaceSystemService)
        {
            _spaceSystemService = spaceSystemService;
        }
        //GET
        [HttpGet]
        [Route("api/[controller]/GetAllSpaceSystems")]
        public IActionResult GetAllSpaceSystems()
        {
            var response = _spaceSystemService.GetAll();
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                return base.Ok(response.ResponseData);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("api/[controller]/GetSpaceSystemById/{id}")]
        public IActionResult GetSpaceSystemById(int id)
        {
            var response = _spaceSystemService.GetById(id);
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                return base.Ok(response.ResponseData);
            }
            return BadRequest(response);
        }
        //POST
        [HttpPost]
        [Route("api/[controller]/SaveSpaceSystem")]
        public IActionResult PostSaveSpaceSystem([FromBody] SpaceSystemModel systemModel)
        {
            var response = _spaceSystemService.PostSave(systemModel);
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                return base.Ok(response);

            }
            return BadRequest(response);
        }
        //PUT
        [HttpPut]
        [Route("api/[controller]/UpdateSpaceSystem")]
        public IActionResult PutUpdateSpaceSystem([FromBody] SpaceSystemModel systemModel)
        {
            var response = _spaceSystemService.PutUpdate(systemModel);
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                return base.Ok(response);

            }
            return BadRequest(response);
        }
        //DELETE
        [HttpDelete]
        [Route("api/[controller]/DeleteSpaceSystem/{id}")]
        public IActionResult DeleteSpaceSystem(int id)
        {
            var response = _spaceSystemService.Delete(id);
            if (response.StatusCode == Enum.StatusCode.Success)
            {
                return base.Ok(response);

            }
            return BadRequest(response);
        }
    }
}

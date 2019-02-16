using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;


namespace MyMachine.Controllers
{   

    [ApiController]
    [Route("api/[controller]")]
    public class MaschineController :ControllerBase
    {
         MaschineBl _bl;

        public MaschineController(MaschineBl bl)
        {
            _bl = bl;
        }

        [Route("")]
        public IActionResult GetAll()
        {
            return Ok( _bl.GetAll());
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(string id)
        {
            return Ok( _bl.Get(id));
        }

        
        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody]MaschineDto dto)
        {
            return Ok( _bl.Save(dto));
           
        }

       

        [HttpGet]
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult delete(Guid id)
        {
            return Ok( _bl.Delete(id));
        }

    }
}

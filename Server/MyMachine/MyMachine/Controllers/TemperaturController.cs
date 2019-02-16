using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMachine.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TemperaturController : ControllerBase
    {
        [Route("getall/{id}")]
        public IActionResult GetAll(string id)
        {
            return Ok(new TemperaturBl().GetAll(id));
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(new TemperaturBl().Get(id));
        }


        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody]TemperaturDto dto)
        {
            return Ok(new TemperaturBl().Save(dto));

        }



        [HttpGet]
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult delete(Guid id)
        {
            return Ok(new TemperaturBl().Delete(id));
        }

    }
}

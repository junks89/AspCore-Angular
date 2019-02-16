using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMachine.Controllers
{
    [ApiController]
    [Route("api/Login/{username}/{password}")]
    public class LoginController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult Login(string username, string password)
        {
            if(username =="gerhard" && password == "123")
            {
                return Ok(new TokenModel() { Token = new TokenTools().CreateToken() });
            }
            return Unauthorized();
        }
    }
}

using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController: ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "number", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
        public IActionResult GetRandomNubmer()
        {
            var rnd = new Random();
            var randomNumber = rnd.Next(2, 13);
            return Ok(randomNumber);
        }
    }
}
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController: ControllerBase
    {
        [HttpGet("")]
        [Authorize(Roles = "number", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
        public IActionResult GetRandomPrimeNumberBetween2And13()
        {
            var primesBetween2And13 = new int[] { 2, 3, 5, 7, 11, 13 };

            var random = new Random();
            var randomPrimeNumber = primesBetween2And13[random.Next(0, primesBetween2And13.Length)];
            return Ok(randomPrimeNumber);
        }
    }
}
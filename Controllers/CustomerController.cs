using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ////GET
        //[HttpGet,Authorize]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "john Doe", "Jane Doe" };
        //}



        [Authorize]
        [HttpGet("cu")]
       
        public IActionResult cu()
        {
            return new JsonResult("Abhi");
        }
    }
}

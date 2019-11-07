using Microsoft.AspNetCore.Mvc;
using ngAlainDemo.Entities;

namespace ngAlainDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AclController:ControllerApiBase
    {
        [HttpPost]
        public JsonResult Post(User user)
        {

        }

       
        
    }
}
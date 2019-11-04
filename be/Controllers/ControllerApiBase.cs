using Microsoft.AspNetCore.Mvc;

namespace ngAlainDemo.Controllers
{
    public class ControllerApiBase:ControllerBase
    {
        public JsonResult Output(object data,string msg="ok")
        {
            return new JsonResult(new 
            {
                data,
                msg
            });
        }
    }
}
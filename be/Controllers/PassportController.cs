using System;
using Microsoft.AspNetCore.Mvc;
using ngAlainDemo.Models;

namespace ngAlainDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController:ControllerApiBase
    {
        /// 登陆验证
        [HttpPost("login")]
        public JsonResult Login(LoginRequest req)
        {
            // 登陆验证成功后 返回token和其他信息
            // 否则返回错误
            if(req.userName=="Demo" && req.password=="123456")
            {

                return Output(new LoginResponse()
                {
                    token="ngAlainDemo",
                    user= new User{
                        name="Demo",
                        email="Demo@demo.com",
                        avatar ="https://ng-alain.com/assets/img/logo-color.svg"
                    }
                });
            }
           else if(req.userName=="Test" && req.password=="123456")
            {

                return Output(new LoginResponse()
                {
                    token="ngAlainDemo",
                    user = new User{
                        name="Test",
                        email="Test@demo.com",
                        avatar ="https://ng-alain.com/assets/img/logo-color.svg"
                    }
                });
            }
            throw new Exception("无效用户");
        }
    }
}
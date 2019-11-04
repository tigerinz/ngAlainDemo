using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ngAlainDemo.Models;

namespace ngAlainDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController:ControllerApiBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            return Output(new App{
                project= new Project{ name="ngAlainDemo"},
                menu= new List<Menu> 
                {
                    new Menu 
                    {
                        text="主导航",
                        group=true,
                        children= new List<Menu>
                        {
                            new Menu
                            {
                                text= "仪表盘",
                                link = "/dashborad",
                                icon = "anticon action-appstore-o"
                            },
                            new Menu
                            {
                                text = "快捷菜单",
                                icon = "acticon acticon-rocket",
                                shortout_root=true
                            }
                        }
                    },
                    new Menu
                    {
                        text = "业务",
                        group = true,
                        children =new List<Menu>
                        {
                            new Menu
                            {
                                text = "CMS",
                                icon = "anticon anticon-skin",
                                children = new List<Menu>
                                {
                                    new Menu
                                    {
                                        text = "CMS列表",
                                        link = "/cms/cmslist"
                                    },
                                    new Menu
                                    {
                                        text = "模块列表",
                                        link = "cms/modulelist"
                                    }
                                }
                            }
                        }
                    
                    }

                },
                user = new User{ id = 1, name = "Demo"}
            });
        }
    }
}
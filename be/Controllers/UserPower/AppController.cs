using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ngAlainDemo.Entities;

namespace ngAlainDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController:ControllerApiBase
    {
        [HttpPost]
        public JsonResult Post(User user)
        {
            return getApp(user.name);
        }

        private JsonResult getApp(string userName)
        {
            if(userName=="Demo"){
            return GetDemo();
            }else if(userName == "Test"){
                return GetTest();
            }
            return null;
        }

        private JsonResult GetDemo()
        {
            return Output(new App
            {
                project = new Project { name = "ngAlainDemo" },
                menu = new List<Menu>
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
                acl = new Acl{
                    ability =new string[]{"add"}
                }
               // user = new User { id = 1, name = "Demo" }
            });
        }

        private JsonResult GetTest()
        {
            return Output(new App
            {
                project = new Project { name = "ngAlainDemo" },
                menu = new List<Menu>
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
                                    },
                                       new Menu
                                    {
                                        text = "Test",
                                        link = "Test"
                                    }
                                }
                            }
                        }

                    }

                },
                   acl = new Acl{
                    ability =new string[]{"search"}
                }
                //user = new User { id = 2, name = "Test" }
            });
        }
    }
}
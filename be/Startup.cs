using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ngAlainDemo.Core;
using ngAlainDemo.Models;

namespace ngAlainDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.Filters.Add(new ExceptionAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
           
#if DEBUG
app.UseCors(bulider => 
{
    bulider.AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin();
});
#endif
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            //除登陆界面其他页面检查token
            app.Use(async(Context,next) => {
                if(!Context.Request.Path.ToString().StartsWith("/api/passport")){
                    var _token = "";
                    if(Context.Request.Headers.TryGetValue("token",out var tokens) && tokens.Count>0){
                        _token=tokens[0];
                    }
                    Console.WriteLine(_token);
                    if(_token != "ngAlainDemo"){
                        Context.Response.StatusCode=401;
                        return;
                    }

                    var user = new User(){
                        id =1,
                        name="demo"
                    };
                    Context.Items.Add("token",_token);
                    Context.Items.Add("user",user);
                }
                await next();
            });
            app.UseMvc();
        }
    }
}

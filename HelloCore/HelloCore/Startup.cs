using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace HelloCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region 类似于.NetFramework中的Application_Start事件
            applicationLifetime.ApplicationStarted.Register(() =>
            {
                Console.WriteLine("Started");
            });

            applicationLifetime.ApplicationStopped.Register(() =>
            {
                Console.WriteLine("Stopped");
            });

            applicationLifetime.ApplicationStopping.Register(() =>
            {
                Console.WriteLine("Stopping");
            });
            #endregion


            #region Map
            app.Map("/maptask", taskapp =>
            {
                taskapp.Run(async (context) =>
                {
                    await context.Response.WriteAsync("From /maptask");
                });
            });

            app.Map("/maptask1/new", taskapp =>
            {
                taskapp.Run(async (context) =>
                {
                    await context.Response.WriteAsync("From /maptask1/new");
                });
            });
            #endregion

            #region Use and Run

            //Func<HttpContext, Func<Task>, Task> middleware
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("1:start \r\n");
                await next();
                await context.Response.WriteAsync("End \r\n");
            });

            //Func<RequestDelegate, RequestDelegate> middleware
            app.Use(next =>
            {
                return (context) =>
                {
                    context.Response.WriteAsync("2:start \r\n");
                    return next.Invoke(context);
                };
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("3:start \r\n");
            });

            #endregion


            app.Run(async (context) =>
        {
                #region 打印配置信息

                await context.Response.WriteAsync(configuration["Connn"] + "\r\n");//打印json配置
                await context.Response.WriteAsync(configuration["name"] + "\r\n");//打印commandling配置

                #endregion

                #region 打印环境变量
                await context.Response.WriteAsync($@"env.ApplicationName: {env.ApplicationName}" + "\r\n");
            await context.Response.WriteAsync($@"env.ContentRootPath: {env.ContentRootPath}" + "\r\n");
            await context.Response.WriteAsync($@"env.EnvironmentName: {env.EnvironmentName}" + "\r\n");
            await context.Response.WriteAsync($@"env.IsDevelopment(): {env.IsDevelopment()}" + "\r\n");
            await context.Response.WriteAsync($@"env.IsProduction(): {env.IsProduction()}" + "\r\n");
            await context.Response.WriteAsync($@"env.IsStaging(): {env.IsStaging()}" + "\r\n");
            await context.Response.WriteAsync($@"env.WebRootPath: {env.WebRootPath}" + "\r\n");
                #endregion

                //tips:使用控制台命令 dotnet watch run 可以在代码修改时直接得到最新的代码结果，不需要重新启动调试
                await context.Response.WriteAsync("Hello World!");
        });

        }
    }
}

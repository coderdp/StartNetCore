using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace OptionsBindSample
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Class>(Configuration);// 注册需要绑定的实例
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();//配置MVC默认的路由

            //Bind读取配置到C#实例
            //app.Run(async (context) =>
            //{
            //    var myclass = new Class();
            //    Configuration.Bind(myclass);
            //    await context.Response.WriteAsync($"{myclass.ClassNo},{myclass.ClassDesc} \r\n");
            //    foreach (var item in myclass.Students)
            //    {
            //        await context.Response.WriteAsync($"name:{item.Name},age:{item.Age} \r\n");
            //    }
            //});
        }
    }
}

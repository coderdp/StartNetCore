using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OptionsBindSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly Class _classAccessor;
        //public HomeController(IOptions<Class> classAccessor)
        //{
        //    _classAccessor = classAccessor.Value;
        //}
        public HomeController(IOptionsSnapshot<Class> classAccessor)//IOptionsSnapshot 使用热更新配置,当appsettings.json改变时，用户刷新页面时会更新页面的值且网站不要重启
        {
            _classAccessor = classAccessor.Value;
        }
        /// <summary>
        /// 默认从IOptions读取配置的绑定值
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_classAccessor);
        }

        /// <summary>
        /// 在页面使用IOC获取配置的值 读取配置的值  url:/home/Index2
        /// </summary>
        /// <returns></returns>
        public IActionResult Index2()
        {
            return View();
        }
    }
}
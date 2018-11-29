# 从零开始学习NetCore

## 配置文件读取

- [命令行配置读取](https://github.com/coderdp/StartNetCore/blob/master/CommandLineSample/CommandLineSample/Program.cs)
- [从json读取配置](https://github.com/coderdp/StartNetCore/blob/master/CommandLineSample/JsonConfigSample/Program.cs) // todo 从控制台读取json配置中文出现乱码待解决。解决问题:json文件编码格式为utf-8时，输出格式正确。
- [Bind读取配置到C#实例](https://github.com/coderdp/StartNetCore/blob/master/CommandLineSample/OptionsBindSample/Startup.cs)
- [MVC使用Ioptions读取配置](https://github.com/coderdp/StartNetCore/blob/master/CommandLineSample/OptionsBindSample/Startup.cs)
- [配置热更新](https://github.com/coderdp/StartNetCore/tree/master/CommandLineSample/OptionsBindSample),[View热更新](https://github.com/coderdp/StartNetCore/blob/master/CommandLineSample/OptionsBindSample/Views/Home/Index2.cshtml)和[Controller的热更新](https://github.com/coderdp/StartNetCore/blob/master/CommandLineSample/OptionsBindSample/Controllers/HomeController.cs)

## 依赖注入

- [了解ASP.NET Core 依赖注入](http://www.jessetalk.cn/2017/11/06/di-in-aspnetcore/) From [Jesse](http://www.jessetalk.cn/who-is-jesse/)

- [DI初始化源码](https://github.com/aspnet/Hosting)
- 源码解析：
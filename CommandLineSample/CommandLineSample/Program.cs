using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
namespace CommandLineSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, string>()
            {
                {"name","Bean"},
                {"age","25"}
            };
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(dic)//从内存读取
                .AddCommandLine(args);//从控制台获取输入参数 or 通过控制台 dotnet run name=666 age=30

            //*注意：配置会覆盖，比如上面的操作：控制台命令会覆盖内存配置

            var configuration = builder.Build();

            Console.WriteLine($"name:{configuration["name"]}");
            Console.WriteLine($"age:{configuration["age"]}");

            Console.ReadLine();
        }
    }
}

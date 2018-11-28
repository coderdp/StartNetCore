using System;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace JsonConfigSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("class.json").Build();//控制台配置json配置

            Console.WriteLine($"ClassNo {configuration["ClassNo"]}");
            Console.WriteLine($"ClassDesc {configuration["ClassDesc"]}");

            Console.WriteLine("Students:");

            Console.WriteLine($"Name:{configuration["Students:0:Name"]}");
            Console.WriteLine($"Age:{configuration["Students:0:Age"]}");

            Console.WriteLine($"Name:{configuration["Students:1:Name"]}");
            Console.WriteLine($"Age:{configuration["Students:1:Age"]}");

            var str = configuration["Students:2:Name"];
            Console.WriteLine($"Name:{configuration["Students:2:Name"]}");//todo中文读取为乱码，待解决。解决问题:json文件编码格式为utf-8时，输出格式正确。
            Console.WriteLine($"Age:{configuration["Students:2:Age"]}");
            Console.ReadLine();
        }
    }
}

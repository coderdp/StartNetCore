# DI初始化源码解读

## 1.WebHostBuilder.Build（）操作

### 1.1BuildCommonServices方法

- 实例化 并返回ServiceCollection，找IStartup类

### 1.2 var host = new WebHost()

- 传入ServiceCollection和ServiceProvider

### 1.3 host.Initialize()

- host.Initialize() ->EnsureApplicationServices()
- EnsureApplicationServices 干两件事。1.拿到到IStartup的实例 2.执行Startup类的ConfigureServices方法，并且传入之前的ServiceCollection

# 图例（来源于[jesse](http://video.jessetalk.cn/course/4/task/20/show)）



![图片](https://portal.qiniu.com/bucket/netcore/resource)
# DI初始化源码解读

## 1.WebHostBuilder.Build（）操作

### 1.1BuildCommonServices方法

- 实例化 并返回ServiceCollection，找IStartup类

### 1.2var host = new WebHost()

- 传入ServiceCollection和ServiceProvider


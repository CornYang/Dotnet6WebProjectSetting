using Dotnet6WebProjectSetting.Sample.API;
using NLog;
using NLog.Web;

// Early init of NLog to allow startup and exception logging, before host is built
// reference: https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-6
NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<StartUp>();
}).UseNLog(); //µù¥UNLog(DI)

builder.Build().Run();

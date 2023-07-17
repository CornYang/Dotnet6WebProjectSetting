using Dotnet6WebProjectSetting.Sample.API;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<StartUp>();
});

builder.Build().Run();

using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using NLog;

namespace Dotnet6WebProjectSetting.Sample.API.Helper
{
    public class RequestLogActionFilter : IActionFilter
    {
        public readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        // reference : https://eugenesu.me/2021/08/20/dotnetcore-actionfilter/
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var API_Path = $"{context.RouteData.Values["controller"]}/{context.RouteData.Values["action"]}";
            _logger.Info($"Request API Path: {API_Path}");

            var HostAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            _logger.Info($"Request HostAddress: {HostAddress}");

            var UserAgent = context.HttpContext.Request.Headers["User-Agent"];
            _logger.Info($"Request UserAgent: {UserAgent}");

            var requestContent = JsonConvert.SerializeObject(context.ActionArguments.FirstOrDefault().Value);
            _logger.Info($"Request Content: {requestContent}");
        }
    }
}

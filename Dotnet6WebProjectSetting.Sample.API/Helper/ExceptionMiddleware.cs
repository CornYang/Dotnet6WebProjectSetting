namespace Dotnet6WebProjectSetting.Sample.API.Helper
{
    //reference : https://eugenesu.me/2021/09/09/dotnetcore-global-error-handler/
    //reference : https://blog.johnwu.cc/article/ironman-day17-asp-net-core-exception-handler.html
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

            }
        }
    }
}

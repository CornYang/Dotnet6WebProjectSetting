using Dotnet6WebProjectSetting.Sample.API.Helper;

namespace Dotnet6WebProjectSetting.Sample.API
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<RequestLogActionFilter>();
            });

            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Middleware 註冊的層級可以在 Filters 的外層，也就是說所有的 Filter 都會經過 Middleware。
            //如果再把 Exception Middleware 註冊在所有 Middleware 的最外層，就可以變成全站的 Exception Handler。
            //Middleware 的註冊順序很重要，越先註冊的會包在越外層。把 ExceptionMiddleware 註冊在越外層，能涵蓋的範圍就越多。
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

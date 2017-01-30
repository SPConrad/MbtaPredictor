using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using MbtaPredictor.Services;
using MbtaPredictor.Entities;
using Microsoft.EntityFrameworkCore;

namespace MbtaPredictor
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            ///TODO Implement ITrain
            services.AddScoped<ITripData, SqlTripData>();
            //services.AddScoped<IVehicleData, sqlVehicleData>();
            ///TODO Implement MbtaDbContext
            services.AddDbContext<MbtaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MbtaPredictor")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context => context.Response.WriteAsync("Oops")
                });
            }

            app.UseFileServer();

            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            ///
            /// CONVENTION BASED ROUTING
            /// 

            // got a request for /Home/Index
            //MVC determines you want HomeController, and the "Index" action

            ///"{controller}" determines that "Controller" will be appended to whatever the first item in the URL is.
            /// So /Home/ becomes HomeController. =Home means if you can't find a Controller, the default will be Home.
            /// action dictates it will be the action, or method
            /// ID becomes an optional item with the ?
            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");

        }
    }
}

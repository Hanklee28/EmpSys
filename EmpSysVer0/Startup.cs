using System.Configuration;
using EmpSysVer0.Helpers;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainEMPDB.Models;

namespace EmpSysVer0
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
       // public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration configuration;



        // 註冊應用程式的服務
        public void ConfigureServices(IServiceCollection services)
        {
            //FOR 環境變數
            services.AddSingleton<IConfiguration>(_configuration);
            services.AddEntityFrameworkSqlServer().AddDbContext<TrainEMPDBcontext>(options =>
            {
                options
                //.UseSqlServer("Data Source =10.11.37.148; Initial Catalog = TrainDB121309; Persist Security Info = True; User ID = 121309; Password = 121309");
                //將連線字串放入appsettings
                //.UseSqlServer("Server=.;Database=EmpData;Trusted_Connection=True;MultipleActiveResultSets=true;Persist Security Info=True;");
                .UseSqlServer(configuration.GetConnectionString("DbString"));

            });
            services.AddMemoryCache();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
        //public static IWebHost BuildWebHost(string[] args)
        //{
        //    return WebHost.CreateDefaultBuilder(args)
        //        .ConfigureLogging(logging =>
        //        {
        //            logging.AddProvider(new Log4netProvider("log4net.config"));
        //        })
        //        .UseStartup<Startup>()
        //        .Build();
        //}
        // 設定 HTTP 請求處理流程
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
        }
    }
}

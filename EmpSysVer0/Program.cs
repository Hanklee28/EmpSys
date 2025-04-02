using System.Reflection;
using EmpSysVer0;
using log4net.Config;
using log4net;
using EmpSysVer0.Helpers;
using Microsoft.AspNetCore;

public class Program
{

    private readonly static ILog _logger = LogManager.GetLogger(typeof(Program));
    public static void Main(string[] args)
    {
        LoadLog4netConfig();
        _logger.Info("Application Start");


        var builder = WebApplication.CreateBuilder(args);


        // 建立 Startup 實例
        var startup = new Startup(builder.Configuration);

        // 註冊服務
        startup.ConfigureServices(builder.Services);

       

        var app = builder.Build();
        // 啟用 CORS
        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        // 設定 HTTP 請求管道
        startup.Configure(app, app.Environment);

        app.Run();
    }
    private static void LoadLog4netConfig()
    {
        var repository = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy)
    );
        XmlConfigurator.Configure(repository, new FileInfo("Configs/Log4net.config"));

    }


}
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();

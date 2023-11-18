using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhB.Repo;
using PhB.Services;
using PhB.Web;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddDbContext<PhB.Repo.AppContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<PhB.Repo.AppContext>();


builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IPhoneBookService), typeof(PhoneBookService));
builder.Services.AddScoped(typeof(IJobService), typeof(JobService));
builder.Services.AddScoped(typeof(IGovernorateService), typeof(GovernorateService));
builder.Services.AddScoped(typeof(ICenterService), typeof(CenterService));


builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();


var app = builder.Build();

//var supportedCultures = new[]
//    {        
//        new CultureInfo("ar-Eg"),
//        new CultureInfo("en-US"),
//        // Add more cultures as needed
//    };
RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions();
localizationOptions.AddSupportedCultures(new[] { "ar-eg", "en-us" });
localizationOptions.SetDefaultCulture("ar-eg");



//app.UseRequestLocalization(new RequestLocalizationOptions
//{
//    DefaultRequestCulture = new RequestCulture("ar-Eg")    
//    ,SupportedCultures = supportedCultures
//    ,SupportedUICultures = supportedCultures
//});

// Configure the HTTP request pipeline.
;
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();



app.UseAuthentication();
app.Use(async (context, next) =>
{
    // Access cookies from Request.Cookies
    if (context.Request.Cookies.TryGetValue("Language", out var myCookieValue))
    {
        // You can now use myCookieValue in your application
        //context.Response.WriteAsync($"Value of myCookie: {myCookieValue}\n");
        localizationOptions.SetDefaultCulture(myCookieValue!= null? myCookieValue.ToString(): "en-us");
        Resource.ArabicCulture = myCookieValue != null && myCookieValue.ToString().Contains("ar") ? true : false;
    }

    // Call the next middleware or endpoint
    await next.Invoke();
});
app.UseRequestLocalization(localizationOptions);

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "ChangeCulture",
//        pattern: "{culture}/change-culture/{**returnUrl}",
//        defaults: new { controller = "Home", action = "ChangeCulture" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=account}/{action=login}/{id?}");

app.Run();

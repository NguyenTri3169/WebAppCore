using Microsoft.EntityFrameworkCore;
using WebAppMVC;
using WebAppMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseDeveloperExceptionPage();
    //app.UseBrowserLink();
}
app.UseStaticFiles();

app.UseRouting();
app.UseWebSockets();

app.UseAuthorization();
//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "Account",
    pattern: "{controller=Account}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

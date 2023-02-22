using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Universe.Models;
using Universe.Services;
using Universe.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddDbContext<DbTestContext>(builder =>
{
    builder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=DbStreaming;Integrated Security=True");
});

builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 2;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

}).AddEntityFrameworkStores<DbTestContext>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

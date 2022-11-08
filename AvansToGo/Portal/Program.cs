using Core.Domain.Services.IRepository;
using Infrastructure.Repository;
using Core.Domain.Services.IServices;
using Core.Domain.Services.Services;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AvansToGoContext>(options => options.UseSqlServer(connectionString));

var userConnectionString = builder.Configuration.GetConnectionString("Security");
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(userConnectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(config =>
{
    config.Password.RequiredLength = 4;
    config.Password.RequireDigit = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddAuthorization(options =>
    options.AddPolicy("StudentOnly", policy => policy.RequireClaim("Student")));

builder.Services.AddAuthorization(options =>
    options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("Employee")));

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "Identiy.Cookie";
    config.LoginPath = "/Account/login";
});

builder.Services.AddScoped<IPackageRepo, PackageEFRepository>();
builder.Services.AddScoped<IStudentRepo, StudentEFRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

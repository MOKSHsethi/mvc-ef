using Assesment_MVC_EF;
using Assesment_MVC_EF.Context;
using Assesment_MVC_EF.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection"));

});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<UserInterface , UserRepo>();
builder.Services.AddTransient<CourseInterface, CourseRepo>();
builder.Services.AddTransient<BatchInterface, BatchRepo>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

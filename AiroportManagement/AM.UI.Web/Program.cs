using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();//hedhi dima mawjouda
builder.Services.AddDbContext<DbContext, AMContext>();//hedhi dima mawjouda
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();//hedhi dima mawjouda
builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));//hedhi dima mawjouda
builder.Services.AddScoped<IserviceFlight,ServiceFlight>();
builder.Services.AddScoped<IServicePlane, ServicePlane>();//etape 2

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

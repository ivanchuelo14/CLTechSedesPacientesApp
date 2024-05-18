using CLTechSedesPacientesApp.Applicattion.Services;
using CLTechSedesPacientesApp.Data;
using CLTechSedesPacientesApp.Data.Repository;
using CLTechSedesPacientesApp.Infraestructure.Configuration;
using CLTechSedesPacientesApp.Infraestructure.Util;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDataBase"));
});

builder.Services.AddScoped(typeof(IRespository<>), typeof(Repository<>));
builder.Services.AddScoped<ISedeService, SedeService>();
builder.Services.AddScoped<IValidationDictionary, CustomValidationDictionary>();

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

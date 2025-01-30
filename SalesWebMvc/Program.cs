using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySql(
    builder.Configuration.GetConnectionString("SalesWebMvcContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SalesWebMvcContext"))));

//Registra serviço no sistema de injeção de dependencias da aplicação.
builder.Services.AddScoped<SeedingService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seedingService = services.GetRequiredService<SeedingService>();
    seedingService.seed();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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

app.Run();

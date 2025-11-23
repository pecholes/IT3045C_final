using Microsoft.EntityFrameworkCore;
using IT3045C_final.Models;
using NSwag;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApiDocument(options => {
    options.PostProcess = document =>
    {
        document.Info = new OpenApiInfo { Title = "IT3045C Final Project API" };
    };
});

builder.Services.AddDbContext<IT3045C_final.Models.AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseOpenApi();
app.UseSwaggerUi();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllers();

Console.WriteLine(AppDomain.CurrentDomain.GetData("DataDirectory"));

app.Run();
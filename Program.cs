using Microsoft.EntityFrameworkCore;
using openmarkethubAPI.Repositories;
using openmarkethubAPI.Services;

var builder = WebApplication.CreateBuilder(args);

//Register masterContext with a connection string
builder.Services.AddDbContext<MasterContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(8, 0, 21))));

//Register services and repositories
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapControllers();
app.UseHttpsRedirection();

app.Run();

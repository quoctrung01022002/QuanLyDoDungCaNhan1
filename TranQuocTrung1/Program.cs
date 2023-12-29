using Microsoft.EntityFrameworkCore;
using TranQuocTrung1.Entities;
using TranQuocTrung1.Models;
using TranQuocTrung1.Repositories;
using TranQuocTrung1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ROCKERContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "http://localhost:4200");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();

                      });
});

builder.Services.AddScoped<IRepository<BerthModel>, BerthRepository>();
builder.Services.AddScoped<IBerthService, BerthService>();
builder.Services.AddScoped<IRepository<ShipModel>, ShipRepository>();
builder.Services.AddScoped<IShipService, ShipService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

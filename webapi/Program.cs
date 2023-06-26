using Bll;
using Dal;
using Dal.Repository;
using Microsoft.EntityFrameworkCore;
using WaterPOC.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      "Any",
      cors =>
      {
          cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
      });
});

builder.Services.AddScoped<IBllFacade, BllFacade>();
builder.Services.AddScoped<IWaterBll, WaterBll>();
builder.Services.AddScoped<IWaterRepository, WaterRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//use configs for connection string
var DatabasePath = builder.Configuration.GetValue<string>("ConnectionStrings:PersonDatabase");

builder.Services.AddDbContext<WaterDbContext>(option =>
option.UseSqlServer(DatabasePath));

var app = builder.Build();
app.UseCors("Any");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

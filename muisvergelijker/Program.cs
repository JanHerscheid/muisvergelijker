using DAL;
using DAL.Handlers;
using DAL.Interfaces;
using Logic;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMouseHandler, MouseHandler>();
builder.Services.AddScoped<IMouseLogic, MouseLogic>();
builder.Services.AddScoped<IModHandler, ModHandler>();
builder.Services.AddScoped<IModLogic, ModLogic>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql("Server=studmysql01.fhict.local;Uid=dbi406978;Database=dbi406978;Pwd=Sudblamzud2;", ServerVersion.AutoDetect("Server=studmysql01.fhict.local;Uid=dbi406978;Database=dbi406978;Pwd=Sudblamzud2;"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://127.0.0.1:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

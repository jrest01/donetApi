
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
// f1
// builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
// f2
var Configuration = builder.Configuration;
builder.Services.AddDbContext<TareasContext>(options => options.UseNpgsql(
    Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddSqlServer<TareasContext>("Server=DESKTOP-K6TGKF2;Database=API;user id=sa; password=admin");
// builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());
builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
builder.Services.AddScoped<ITareaServices, TareaServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
// init customs middlewares
// app.UseWelcomePage();

app.UseTimeMiddleware();
// end customs middlewares
app.MapControllers();

app.Run();

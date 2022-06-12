using Microsoft.EntityFrameworkCore;
using ViceriWebApi.Data;
using ViceriWebApi.Repository;
using ViceriWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Repository
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

// Service
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

// DbContext
builder.Services.AddTransient<IAppDbContext, AppDbContext>();

// Add services to the container.
builder.Services.AddControllers();

//Adds
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

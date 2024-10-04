using BoardGameGeekClient;
using Business.Services;
using Microsoft.EntityFrameworkCore;
using Providers;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "corsPolicy";

// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<UnitOfWork>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<BoardGameGeekService>();

builder.Services.AddCors(options => options.AddPolicy(name: corsPolicy, builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

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

app.UseCors(corsPolicy);

app.Run();

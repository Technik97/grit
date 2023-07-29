using Microsoft.EntityFrameworkCore;
using Npgsql;

using Grit.HabitService.Interfaces;
using Grit.HabitService.Services;
using Grit.Database;


var builder = WebApplication.CreateBuilder(args);

var dsBuilder = new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("Postgres"));
var dbDataSource = dsBuilder.Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IHabitService, HabitService>();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GritDbContext>(options =>
{
    options.UseNpgsql(dbDataSource);
});

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

using Microsoft.EntityFrameworkCore;
using Npgsql;

using Grit.HabitService.Interfaces;
using Grit.HabitService.Services;
using Grit.Database;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var dsBuilder = new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("Postgres"));
var dbDataSource = dsBuilder.Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddTransient<IHabitService, HabitService>();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GritDbContext>(options =>
{
    options.UseNpgsql(dbDataSource);
});

// Use localhost as ConnectionString if you're using redis on local machine.
builder.Services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")));

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

// Using our Custom Redis Cache store
builder.Services.AddRedisOutputCache(Options => 
{
    Options.AddBasePolicy(builder =>
        builder.Expire(TimeSpan.FromSeconds(60)));
    Options.AddPolicy("EnableCacheForHabits", builder =>
    {
        builder.Cache();
        builder.Tag("habits_tag");
    });
});

var app = builder.Build();

app.UseOutputCache();

app.UseCors();

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

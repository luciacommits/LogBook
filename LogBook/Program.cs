using Microsoft.EntityFrameworkCore;
using LogBook.Data;
using LogBookServices.Interfaces;
using LogBookServices.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<LogBookDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ITopicService, TopicService>();

builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddScoped<ILogUserService, LogUserService>();

builder.Services.AddScoped<ILogSessionService, LogSessionService>();

builder.Services.AddScoped<IExerciseService, ExerciseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

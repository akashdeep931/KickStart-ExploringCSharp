using Microsoft.EntityFrameworkCore;
using TodoDemo.Api.Data;
using TodoDemo.Api.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the Web Application

builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoDb"));

builder.Services.AddControllers();

builder.Services.AddScoped<ITodoRepository, TodoEfRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add middleware to the request/response pipeline (order is important)

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();


app.Run();  // Run the Web Applications

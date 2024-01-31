using NeatStreakBackEnd.Services;
using NeatStreakBackEnd.Services.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ChoreItemService>();
builder.Services.AddScoped<PasswordService>();

var connectionString = builder.Configuration.GetConnectionString("MyChoreString");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

//CORS policy resolution, call it again at bottom
builder.Services.AddCors(options =>
{
    options.AddPolicy("ChorePolicy",
    builder =>
    {
        builder.WithOrigins("http://localhost:7125") //match front end url
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("ChorePolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

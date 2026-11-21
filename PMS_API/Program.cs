using Microsoft.EntityFrameworkCore;
using PMS_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Register Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//link with React
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("ReactPolicy");



app.UseCors("ReactPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

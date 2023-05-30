using Microsoft.EntityFrameworkCore;
using MaquinaApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DrinksContext>(opt =>
    opt.UseInMemoryDatabase("DrinkList"));
builder.Services.AddDbContext<CoinsBoxContext>(opt =>
    opt.UseInMemoryDatabase("CoinsBoxList"));
builder.Services.AddDbContext<LogMessagesContext>(opt =>
    opt.UseInMemoryDatabase("LogMessagesList"));
builder.Services.AddDbContext<DadosMesMessagesContext>(opt =>
    opt.UseInMemoryDatabase("DadosMesMessagesList"));
builder.Services.AddDbContext<DadosAnoMessagesContext>(opt =>
    opt.UseInMemoryDatabase("DadosAnoMessagesList"));
builder.Services.AddDbContext<DadosDiaMessagesContext>(opt =>
    opt.UseInMemoryDatabase("DadosDiaMessagesList"));


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

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

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

using backend.Data;
using backend.Services.Treinadores;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pokemon API",
        Version = "v1",
        Description = "API para gerenciamento de treinadores e Pokémon.",
        Contact = new OpenApiContact
        {
            Name = "Gabriel Santos",
            Email = "devgtrue@gmail.com@example.com",
            Url = new Uri("https://github.com/bieltrue95") 
        }
    });


});

builder.Services.AddScoped<ITreinadoresInterface, TreinadoresService>();

builder.Services.AddDbContext<PokemonAPIDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokemon API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

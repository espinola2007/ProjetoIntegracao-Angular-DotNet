
using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=minhaapi.db"));

builder.Services.AddOpenApi();

// Permite que o Angular acesse a API
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRouting();

// Ativa a política de CORS
app.UseCors("PermitirAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();

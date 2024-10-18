using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FuelDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<FuelTicketService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EmployeeService>();

// Agrega controladores
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

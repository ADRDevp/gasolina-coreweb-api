using Microsoft.EntityFrameworkCore;
using gasolina_asp.net_core_web_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura los servicios necesarios para el proyecto

// Agrega el DbContext con la cadena de conexión
builder.Services.AddDbContext<FuelDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agrega los servicios creados para los procedimientos almacenados (SP)
builder.Services.AddScoped<FuelTicketService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EmployeeService>();

// Agrega controladores
builder.Services.AddControllers();

// Agrega Swagger para documentar la API (opcional, pero recomendado para ver los endpoints en el navegador)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Seguridad y manejo de peticiones
app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear controladores (hace que los endpoints definidos en los controladores estén disponibles)
app.MapControllers();

app.Run();

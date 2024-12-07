using asignar_saldos.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar los servicios en el contenedor de dependencias
builder.Services.AddScoped<SaldoService>();

// Agregar controladores (API)
builder.Services.AddControllers();

// Configuración de la cadena de conexión
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

// Configurar el middleware de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


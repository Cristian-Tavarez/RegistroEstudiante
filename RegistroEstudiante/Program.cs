using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.Contexto;
using RegistroEstudiante.Components;
using RegistroEstudiante.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔹 REGISTRO DE SERVICIOS
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<EstudiantesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<AsignaturasService>();

// 🔴 ESTA LÍNEA FALTABA
builder.Services.AddScoped<EstudiantesService>();

// 🔹 AQUÍ recién se construye la app
var app = builder.Build();

// 🔹 MIDDLEWARE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

builder.Services.AddScoped<AsignaturasService>();


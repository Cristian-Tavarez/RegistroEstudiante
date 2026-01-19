using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.Contexto;
using RegistroEstudiante.Components;
using RegistroEstudiante.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔹 REGISTRO DE SERVICIOS
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<EstudiantesContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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

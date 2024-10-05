using MVC.ApiService;
using MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AdministradorService>();
//builder.Services.AddHttpClient<IApiClient<Administrador>, ApiClient<Administrador>>();
builder.Services.AddHttpClient(); // Registra HttpClient

// Agregar servicios de sesi�n
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Configura el tiempo de espera de la sesi�n
    options.Cookie.HttpOnly = true; // La cookie solo se puede acceder a trav�s de HTTP
    options.Cookie.IsEssential = true; // La cookie es esencial para la aplicaci�n
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


// Aseg�rate de que UseSession est� antes de UseAuthorization
app.UseSession(); // Aseg�rate de que se llama antes de UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Administrador}/{action=Index}");

app.Run();

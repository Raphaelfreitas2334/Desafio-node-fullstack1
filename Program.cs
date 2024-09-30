using Microsoft.EntityFrameworkCore;
using projeto_cinema.Data;
using projeto_cinema.Repositorios;
using Template.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adiciona o contexto do banco de dados ao contêiner de serviços
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddScoped<IEventosRepositorio, EventosRepositorio>();
builder.Services.AddScoped<ILocaisRepositorio, LocaisRepositorio>();

builder.Services.AddSwaggerConfiguration(); // Adiciona a configuração do Swagger

var app = builder.Build();

// Configurar o pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration(); // Usa a configuração do Swagger
}

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

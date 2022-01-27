using Loja.Catalogo.Aplicacao.Automapper;
using Loja.Catalogo.Aplicacao.Services;
using Loja.Catalogo.Data.Context;
using Loja.Catalogo.Data.Repository;
using Loja.Catalogo.Dominio.Events;
using Loja.Catalogo.Dominio.Interfaces;
using Loja.Catalogo.Dominio.Services;
using Loja.Core.Comunicacao;
using Loja.WebApp.MVC.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDbContext<CatalogoContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
        options.EnableSensitiveDataLogging();
    }
);

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAutoMapper(typeof(EntidadeParaDTOProfile), typeof(DTOParaEntidadeProfile));

builder.Services.AddMediatR(typeof(Program));

//Mediator
builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();

// Catalogo
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddScoped<IProdutoAppService, ProdutoAppService>();

builder.Services.AddScoped<IEstoqueService, EstoqueService>();

builder.Services.AddScoped<CatalogoContext>();

builder.Services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventoHandler>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vitrine}/{action=Index}/{id?}");

app.Run();

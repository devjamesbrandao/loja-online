using Loja.Catalogo.Aplicacao.Automapper;
using Loja.Catalogo.Aplicacao.Services;
using Loja.Catalogo.Data.Context;
using Loja.Catalogo.Data.Repository;
using Loja.Catalogo.Dominio;
using Loja.Catalogo.Dominio.Events;
using Loja.Catalogo.Dominio.Interfaces;
using Loja.Core.Comunicacao;
using Loja.Core.Message.MensagensComum.EventoDeIntegracao;
using Loja.Core.Message.Notificacoes;
using Loja.Pagamento.Anticorrupcao.Facade;
using Loja.Pagamento.Anticorrupcao.Interfaces;
using Loja.Pagamento.Anticorrupcao.Services;
using Loja.Pagamento.Data.Context;
using Loja.Pagamento.Data.Repository;
using Loja.Pagamento.Dominio.Eventos;
using Loja.Pagamento.Dominio.Interfaces;
using Loja.Pagamento.Dominio.Services;
using Loja.Venda.Aplicacao.Commands;
using Loja.Venda.Aplicacao.Events;
using Loja.Venda.Aplicacao.Handler;
using Loja.Venda.Aplicacao.Queries;
using Loja.Venda.Data.Context;
using Loja.Venda.Data.Repository;
using Loja.Venda.Dominio.Interfaces;
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
    }
);

builder.Services.AddDbContext<VendasContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
    }
);


builder.Services.AddDbContext<PagamentoContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
    }
);

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAutoMapper(typeof(EntidadeParaDTOProfile), typeof(DTOParaEntidadeProfile));

builder.Services.AddMediatR(typeof(Program));

// Notificacoes
builder.Services.AddScoped<INotificationHandler<NotificacaoDominio>, NotificacaoDominioHandler>();

//Mediator
builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();

// Catalogo
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddScoped<IProdutoAppService, ProdutoAppService>();

builder.Services.AddScoped<IEstoqueService, EstoqueService>();

builder.Services.AddScoped<CatalogoContext>();

builder.Services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventoHandler>();

builder.Services.AddScoped<INotificationHandler<PedidoIniciadoEvent>, ProdutoEventoHandler>();

// Vendas
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

builder.Services.AddScoped<IPedidoQueries, PedidoQueries>();

builder.Services.AddScoped<VendasContext>();

builder.Services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();

builder.Services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();

builder.Services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, PedidoCommandHandler>();

builder.Services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();

builder.Services.AddScoped<IRequestHandler<IniciarPedidoCommand, bool>, PedidoCommandHandler>();

builder.Services.AddScoped<INotificationHandler<PedidoEstoqueRejeitadoEvent>, PedidoEventHandler>();

builder.Services.AddScoped<INotificationHandler<PedidoPagamentoRealizadoEvent>, PedidoEventHandler>();

builder.Services.AddScoped<INotificationHandler<PedidoPagamentoRecusadoEvent>, PedidoEventHandler>();

// Pagamento
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();

builder.Services.AddScoped<IPagamentoService, PagamentoService>();

builder.Services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();

builder.Services.AddScoped<IPayPalGateway, PayPalGateway>();

builder.Services.AddScoped<IConfigurationManager, Loja.Pagamento.Anticorrupcao.Services.ConfigurationManager>();

builder.Services.AddScoped<PagamentoContext>();

builder.Services.AddScoped<INotificationHandler<PedidoEstoqueConfirmadoEvent>, PagamentoEventHandler>();

// Eventos
builder.Services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();

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

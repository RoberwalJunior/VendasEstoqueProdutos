using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VendasEstoqueProdutos.Shared.Application.Interfaces;
using VendasEstoqueProdutos.Shared.Application.ServiceApp;
using VendasEstoqueProdutos.Shared.Domain.Entities;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Repositories;
using VendasEstoqueProdutos.Shared.Domain.Interfaces.Services;
using VendasEstoqueProdutos.Shared.Domain.Services;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Context;
using VendasEstoqueProdutos.Shared.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IModeloProdutoRepository, ModeloProdutoRepository>();
builder.Services.AddTransient<IVendaRepository, VendaRepository>();
builder.Services.AddTransient<IItemVendaRepository, ItemVendaRepository>();

builder.Services.AddTransient<IEmpresaService, EmpresaService>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<IModeloProdutoService, ModeloProdutoService>();
builder.Services.AddTransient<IVendaService, VendaService>();
builder.Services.AddTransient<IItemVendaService, ItemVendaService>();

builder.Services.AddTransient<IEmpresaServiceApp, EmpresaServiceApp>();
builder.Services.AddTransient<IProdutoServiceApp, ProdutoServiceApp>();
builder.Services.AddTransient<IModeloProdutoServiceApp, ModeloProdutoServiceApp>();
builder.Services.AddTransient<IClienteServiceApp, ClienteServiceApp>();
builder.Services.AddTransient<IVendaServiceApp, VendaServiceApp>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserServiceApp, UserServiceApp>();
builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
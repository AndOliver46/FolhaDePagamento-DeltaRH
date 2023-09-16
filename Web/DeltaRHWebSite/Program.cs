using DeltaRHWebSite.Controllers;
using DeltaRHWebSite.Infrastructure;
using DeltaRHWebSite.Infrastructure.Repositories;
using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var _configuration = provider.GetRequiredService<IConfiguration>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ColaboradorService>();
builder.Services.AddTransient<ColaboradorController>();
builder.Services.AddSingleton<EmpresaService>();
builder.Services.AddTransient<EmpresaController>();

builder.Services.AddTransient<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddTransient<IMissaoVisaoValoresRepository, MissaoVisaoValoresRepository>();
builder.Services.AddTransient<INormaRegraRepository, NormaRegraRepository>();
builder.Services.AddTransient<IPoliticaDisciplinarRepository, PoliticaDisciplinarRepository>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Verificar se o emissor do token é válido
        ValidateAudience = true, // Verificar se a audiência do token é válida
        ValidateLifetime = true, // Verificar se o token não está expirado
        ValidateIssuerSigningKey = true, // Verificar a chave de assinatura do token
        ValidIssuer = _configuration["JwtSettings:Issuer"], // Substitua pelo emissor real
        ValidAudience = _configuration["JwtSettings:Audience"], // Substitua pela audiência real
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"])) // Substitua pela chave real
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

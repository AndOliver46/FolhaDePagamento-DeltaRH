using DeltaRHWebSite.Controllers;
using DeltaRHWebSite.Infrastructure;
using DeltaRHWebSite.Infrastructure.Repositories;
using DeltaRHWebSite.Infrastructure.Repositories.Interfaces;
using DeltaRHWebSite.Services;

var builder = WebApplication.CreateBuilder(args);

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

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using PeopleFirst.Infra.Data.Context;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Repositories;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Application.Services;
using PeopleFirstAPI.Configurations;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var jwtSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSection);

var jwtSettings = jwtSection.Get<JwtSettings>();
var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);    


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "PeopleFirst API",
        Version = "v1"
    });



    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Insira o token JWT: Bearer {seu_token}",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            // ValidIssuer = "MinhaAPI",
            // ValidAudience = "MinhaAPI",
            // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(key)

        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers(); // <- Adiciona os controllers à aplicação


// Adicionar serviço do banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PeopleFirstDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddScoped<IAvaliacaoColaboradorRepository, AvaliacaoColaboradorRepository>();
builder.Services.AddScoped<ITipoCompetenciaRepository, TipoCompetenciaRepository>();
builder.Services.AddScoped<IPilarCompetenciaRepository, PilarCompetenciaRepository>();
builder.Services.AddScoped<IItemPilarRepository, ItemPilarRepository>();
builder.Services.AddScoped<IAvaliacaoColaboradorItemPilarRepository, AvaliacaoColaboradorItemPilarRepository>();
builder.Services.AddScoped<ITipoFeedbackRepository, TipoFeedbackRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<ITimeRepository, TimeRepository>();
builder.Services.AddScoped<ITimeColaboradorRepository, TimeColaboradorRepository>();
builder.Services.AddScoped<IHappinessRepository, HappinessRepository>();
builder.Services.AddScoped<IPilarHappinessRepository, PilarHappinessRepository>();
builder.Services.AddScoped<IOpiniaoPilarHappinessRepository, OpiniaoPilarHappinessRepository>();
builder.Services.AddScoped<IDominioAgilidadeRepository, DominioAgilidadeRepository>();
builder.Services.AddScoped<IPilarDominioRepository, PilarDominioRepository>();
builder.Services.AddScoped<IQuestaoPilarRepository, QuestaoPilarRepository>();
builder.Services.AddScoped<IHealthCheckRepository, HealthCheckRepository>();
builder.Services.AddScoped<IAvaliacaoHealthCheckRepository, AvaliacaoHealthCheckRepository>();



builder.Services.AddScoped<IPerfilAppService, PerfilAppService>();
builder.Services.AddScoped<IColaboradorAppService, ColaboradorAppService>();
builder.Services.AddScoped<IAvaliacaoColaboradorAppService, AvaliacaoColaboradorAppService>();
builder.Services.AddScoped<ITipoCompetenciaAppService, TipoCompetenciaAppService>();
builder.Services.AddScoped<IPilarCompetenciaAppService, PilarCompetenciaAppService>();
builder.Services.AddScoped<IItemPilarAppService, ItemPilarAppService>();
builder.Services.AddScoped<IAvaliacaoColaboradorItemPilarAppService, AvaliacaoColaboradorItemPilarAppService>();
builder.Services.AddScoped<IFeedbackAppService, FeedbackAppService>();
builder.Services.AddScoped<IPilarHappinessAppService, PilarHappinessAppService>();
builder.Services.AddScoped<IOpiniaoPilarHappinessAppService, OpiniaoPilarHappinessAppService>();
builder.Services.AddScoped<ITipoFeedbackAppService, TipoFeedbackAppService>();
builder.Services.AddScoped<ITimeAppService, TimeAppService>();
builder.Services.AddScoped<ITimeColaboradorAppService, TimeColaboradorAppService>();
builder.Services.AddScoped<IHappinessAppService, HappinessAppService>();
builder.Services.AddScoped<IDominioAgilidadeAppService, DominioAgilidadeAppService>();
builder.Services.AddScoped<IPilarDominioAppService, PilarDominioAppService>();
builder.Services.AddScoped<IQuestaoPilarAppService, QuestaoPilarAppService>();
builder.Services.AddScoped<IHealthCheckAppService, HealthCheckAppService>();
builder.Services.AddScoped<IAvaliacaoHealthCheckAppService, AvaliacaoHealthCheckAppService>();




var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapControllers(); // <- Mapeia os endpoints dos controllers

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

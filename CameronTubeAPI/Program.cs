global using AutoMapper;
using CameronTubeAPI.Data;
using CameronTubeAPI.Mapping;
using CameronTubeAPI.Models;
using CameronTubeAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CamDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("CamTubeConnection"));
});
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
        .EnableTokenAcquisitionToCallDownstreamApi()
            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
            .AddInMemoryTokenCaches();
builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Video>, Repository<Video>>();
builder.Services.AddScoped<IRepository<Statistics>, Repository<Statistics>>();
builder.Services.AddScoped<IRepository<LinkTable>, Repository<LinkTable>>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(o =>
{
    o.GroupNameFormat = "'v'VVV";
    o.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/swagger/v1/swagger.json", "CamTubeAPI_V1");
        o.SwaggerEndpoint("/swagger/v2/swagger.json", "CamTubeAPI_V2");
        //o.RoutePrefix = String.Empty;

    });
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

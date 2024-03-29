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
using CameronTubeAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using CameronTubeAPI.Helper;

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

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AManager", policy => policy.AddRequirements(new GroupRequirement("964fd566-ec71-49cb-a61c-641e346cc07f")));
    // options.AddPolicy("user", policy => policy.RequireClaim("groups", "user"));
    options.AddPolicy("Auser", policy => policy.AddRequirements(new GroupRequirement("34510532-0f18-4aa4-a7dc-7b8bf0b62b36")));

});

builder.Services.AddControllers();
builder.Services.AddTransient<IAuthorizationHandler, GroupAuthHandler>();
builder.Services.AddScoped<IRepository<Video>, Repository<Video>>();
builder.Services.AddScoped<IRepository<Statistics>, Repository<Statistics>>();
builder.Services.AddScoped<IRepository<LinkTable>, Repository<LinkTable>>();
builder.Services.AddScoped<BlobHelper, BlobHelper>();
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

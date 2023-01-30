global using Qkart_WebAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Qkart_WebAPI.Data;
using Qkart_WebAPI.Mapping;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QkartDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("QKartSQLDb"));
});
//builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddResponseCaching();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddScoped<IRepository<Seller>, Repository<Seller>>();
builder.Services.AddScoped<IRepository<LinkProductSeller>, Repository<LinkProductSeller>>();
builder.Services.AddScoped<IUserRespository<LocalUser>, UserRepoistory<LocalUser>>();
builder.Services.AddControllers().AddNewtonsoftJson();

var key = builder.Configuration.GetValue<string>("ApiSetting:Secret");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


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
builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",

        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    o.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                },
                Scheme="oauth2",
                Name="Bearer",
                In=ParameterLocation.Header,
            },

            new string[] {}
        },

    });
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Qkart API_V1"
    });
    o.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "Qkart API_V2"
    });
});
builder.Services.AddControllers(o =>
{
    o.CacheProfiles.Add("Cache30", new CacheProfile
    {
        Duration = 30,
        Location = ResponseCacheLocation.Any,
        NoStore = false
    });
    o.CacheProfiles.Add("UserAgent", new CacheProfile
    {
        Duration = 120,
        Location = ResponseCacheLocation.Client,
        NoStore = false,
        VaryByHeader = "User-Agent"
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/swagger/v1/swagger.json", "QkartAPI_V1");
        o.SwaggerEndpoint("/swagger/v2/swagger.json", "QkartAPI_V2");
    });
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCaching();
app.MapControllers();

app.Run();

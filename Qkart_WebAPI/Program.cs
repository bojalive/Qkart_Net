global using Qkart_WebAPI.Repository;
using Qkart_WebAPI.Data;
using Qkart_WebAPI.Mapping;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QkartDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("QKartSQLDb"));
});
//builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

using MarketAssistant.Business;
using MarketAssistant.Data;
using MarketAssistant.IBusiness;
using MarketAssistant.Web.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200");
                      });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(MyAllowSpecificOrigins);
    app.UseSwagger();
    app.UseSwaggerUI();
   
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

Helpers.AddTestData(app);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddDbContext<MarketContext>(options => options.UseInMemoryDatabase("MarketDb"));

    services.AddScoped<IBookService, BookService>();
    services.AddScoped<IAuthorService, AuthorService>();
    services.AddScoped<IMarketerService, MarketerService>();
}



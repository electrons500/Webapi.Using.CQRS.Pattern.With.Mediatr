using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Models.Data.MyShopContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<MyshopContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {

    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "CQRS Pattern with Mediatr",
            Description = "This API service uses CQRS Pattern with mediatr for CRUD operations",
            Version = "v1",
            Contact = new OpenApiContact
            {
                Name = "Ishmael Kwaw Obeng",
                Email = "electrons500@gmail.com",
                Url = new Uri("https://www.linkedin.com/in/ishmael-obeng")
            }
        });

  
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
app.UseSwagger();


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hubtel API");

});

app.Run();

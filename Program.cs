using JEdAPI.Models;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

    builder.Services.AddScoped<IMovieRepository, MovieRepository>();

var app = builder.Build();

var devCorsPolicy = "devCorsPolicy";
//var securl =builder.Configuration.GetSection("JWTSettings");




// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(devCorsPolicy, builder => {
//     //builder.WithOrigins("http://localhost:800").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//     builder.WithOrigins("http://localhost:5252/api".ToString())
//                                        .AllowAnyHeader()
//                                        .AllowAnyMethod()

//                                        .AllowCredentials();
//         //builder.AllowAnyOrigin().WithMethods("GET", "PUT", "PATCH", "POST", "DELETE", "OPTIONS").AllowAnyHeader();
//         //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
//         //builder.SetIsOriginAllowed(origin => true);
//     });
// });




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
        builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

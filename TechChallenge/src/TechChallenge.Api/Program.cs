using TechChallenge.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
app.UseSwaggerConfiguration(app.Environment);
app.UseApiConfiguration();
app.Run();

using Api.Interfaces;
using Api.Providers;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProviderManager, ProviderManager>();
builder.Services.AddScoped<IGiftCardProvider, PraxellProvider>();
builder.Services.AddScoped<IGiftCardProvider, AnotherProvider>();
builder.Services.AddScoped<IGiftCardProvider, HaperNumberOneProvider>();
builder.Services.AddScoped<IGiftCardService, GiftCardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
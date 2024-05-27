using Microsoft.Extensions.Options;
using OxfordDictionaries.Api.Models;
using OxfordDictionariesHttpClient;
using OxfordDictionariesHttpClient.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<HttpClientSettings>(builder.Configuration.GetSection("HttpClientSettings"));

builder.Services.AddHttpClient<IHttpGet, HttpClientHelper>((sp, client) =>
{
	var httpClientSettings = sp.GetRequiredService<IOptions<HttpClientSettings>>().Value;
	client.BaseAddress = new Uri(httpClientSettings.BaseAddress);
	client.DefaultRequestHeaders.Add("app_id", httpClientSettings.AppId);
	client.DefaultRequestHeaders.Add("app_key", httpClientSettings.AppKey);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

#region Example
var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
	var forecast = Enumerable.Range(1, 5).Select(index =>
		new WeatherForecast
		(
			DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
			Random.Shared.Next(-20, 55),
			summaries[Random.Shared.Next(summaries.Length)]
		))
		.ToArray();
	return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
#endregion

app.MapGet("/words", async (IHttpGet httpGet) =>
{
	var result = httpGet.GetAsync<string>("words/en-gb?q=about", null).Result;



	return Results.Ok(result);

});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


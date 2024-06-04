using Microsoft.Extensions.Options;
using OxfordDictionaries.Api.Models;
using OxfordDictionariesHttpClient;
using OxfordDictionariesHttpClient.Interfaces;

var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("/words", async (IHttpGet httpGet) =>
{
	var result = httpGet.GetAsync<Root>("words/en-gb?q=about", null).Result;
	return Results.Ok(result);
});

app.Run();

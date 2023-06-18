using ArklensApiFaker.Generator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddScoped<ICharacterGenerator, CharacterGenerator>();
		builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
		{
			options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
			options.SerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
			options.SerializerOptions.WriteIndented = true;
		});

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.MapGet("/character/fake", (
			[FromServices] ICharacterGenerator charGen, 
			[FromQuery] int? count) =>
		{
			count ??= 1;
			return Enumerable.Range(1, count.Value)
				.Select(_ => charGen.Generate())
				.ToArray();
		})
		.WithName("GenerateCharacter")
		.WithOpenApi();
		app.MapGet("/map", () =>
		{
			return Results.File(File.OpenRead("Files\\Map.png"), "image/png", "map.png");
		})
		.WithName("GetMap")
		.WithOpenApi();

		app.Run();
	}
}

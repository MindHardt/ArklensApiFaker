using ArklensApiFaker.Generator;
using Microsoft.AspNetCore.Http.Json;
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
		builder.Services.Configure<JsonOptions>(options =>
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

		app.MapGet("/character/fake", (ICharacterGenerator charGen) =>
		{
			return charGen.Generate();
		})
		.WithName("GenerateCharacter")
		.WithOpenApi();

		app.Run();
	}
}

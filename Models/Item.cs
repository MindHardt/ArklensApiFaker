namespace ArklensApiFaker.Models;

public record Item(
	string Name,
	Money Price,
	string ImageUrl,
	int Quantity = 1)
{
}

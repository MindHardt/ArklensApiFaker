namespace ArklensApiFaker.Models;

public record Item(
	string Name,
	Money Price,
	int Quantity = 1)
{
}

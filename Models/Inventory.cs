namespace ArklensApiFaker.Models;

public record Inventory(
	Money Money,
	IReadOnlyCollection<Item> Items)
{

}

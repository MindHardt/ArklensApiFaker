namespace ArklensApiFaker.Models;

public record Money(
	int Gold,
	int Silver,
	int Copper)
{
	public decimal TotalGold => Gold + Silver * 0.1m + Copper * 0.01m;
}

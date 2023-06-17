namespace ArklensApiFaker.Models;

public record Stat(
	int Class,
	int Additional)
{
	public int Total => Class + Additional;
}

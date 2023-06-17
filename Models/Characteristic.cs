namespace ArklensApiFaker.Models;

public record Characteristic(int Base)
{
	public int Value => Base / 2 - 5;
}

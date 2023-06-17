namespace ArklensApiFaker.Models;

public record Skill(
	bool Class,
	int Points)
{
	public int Total => Points + GetClassBonus();

	private int GetClassBonus() => Points > 0 && Class ? 3 : 0;
}

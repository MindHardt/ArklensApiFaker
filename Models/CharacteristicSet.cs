using Bogus;

namespace ArklensApiFaker.Models;

public record CharacteristicSet(
	Characteristic Strength,
	Characteristic Dexterity,
	Characteristic Constitution,
	Characteristic Intelligence,
	Characteristic Wisdom,
	Characteristic Charisma)
{
}

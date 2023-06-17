using Bogus;
using static Bogus.DataSets.Name;

namespace ArklensApiFaker.Models;

public record Character(
	PersonalInfo PersonalInfo,
	Race Race,
	Class Class,
	CharacteristicSet Characteristics,
	StatSet Stats,
	SkillSet Skills,
	Inventory Inventory)
{
}

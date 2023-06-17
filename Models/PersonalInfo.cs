using static Bogus.DataSets.Name;

namespace ArklensApiFaker.Models;

public record PersonalInfo(
	string Name,
	string Gender,
	int Age,
	string Alignment,
	string PortraitUrl,
	string Background)
{
}

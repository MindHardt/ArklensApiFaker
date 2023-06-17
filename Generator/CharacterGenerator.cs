using ArklensApiFaker.Models;
using Bogus;
using static Bogus.DataSets.Name;

namespace ArklensApiFaker.Generator;

public class CharacterGenerator : ICharacterGenerator
{
	private readonly Faker _faker = new("ru");

	public Character Generate() => new(
			GeneratePersonalInfo(_faker.PickRandom<Gender>()),
			GenerateRace(),
			GenerateClass(),
			GenerateCharacteristicSet(),
			GenerateStatSet(),
			GenerateSkillSet(),
			GenerateInventory());

	private PersonalInfo GeneratePersonalInfo(Gender gender) => new(
		_faker.Name.FullName(gender),
		gender is Gender.Male ? "Мужчина" : "Женщина",
		_faker.Random.Int(18, 50),
		_faker.PickRandom(_alignmentNames),
		_faker.Image.LoremFlickrUrl(),
		_faker.Lorem.Paragraph());

	private readonly string[] _alignmentNames =
	{
		"Законно-доброе",
		"Нейтрально-доброе",
		"Хаотично-доброе",
		"Законно-нейтральное",
		"Нейтральное",
		"Хаотично-нейтральное",
		"Законно-злое",
		"Нейтрально-злое",
		"Хаотично-злое"
	};

	private Race GenerateRace() => new(
		_faker.PickRandom(_raceNames));

	private readonly string[] _raceNames =
	{
		"Человек",
		"Эльф",
		"Дварф",
		"Китсуне",
		"Минас",
		"Серпент"
	};

	private Class GenerateClass() => new(
		_faker.PickRandom(_classNames));

	private readonly string[] _classNames =
	{
		"Бард",
		"Варвар",
		"Воин",
		"Волшебник",
		"Друид",
		"Жрец",
		"Кинетик",
		"Книгочей",
		"Монах",
		"Паладин",
		"Плут",
		"Рейнджер"
	};

	private CharacteristicSet GenerateCharacteristicSet() => new(
		GenerateCharacteristic(),
		GenerateCharacteristic(),
		GenerateCharacteristic(),
		GenerateCharacteristic(),
		GenerateCharacteristic(),
		GenerateCharacteristic());

	private Characteristic GenerateCharacteristic() => new(Enumerable.Range(0, 4)
		.Select(_ => _faker.Random.Int(1, 6))
		.OrderByDescending(t => t)
		.Take(3)
		.Sum());

	private StatSet GenerateStatSet() => new(
		GenerateStat(),
		GenerateStat(),
		GenerateStat(),
		GenerateStat(),
		GenerateStat());

	private Stat GenerateStat() => new(
		_faker.Random.Int(0, 10),
		_faker.Random.Int(1, 10).OrDefault(_faker, 0.8f));

	private SkillSet GenerateSkillSet() => new(
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill(),
		GenerateSkill());

	private Skill GenerateSkill() => new(_faker.Random.Bool(), _faker.Random.Int(0, 20));

	private Inventory GenerateInventory() => new(
		GenerateMoney(),
		GenerateItems());

	private Money GenerateMoney() => new(
		_faker.Random.Int(0, 1000),
		_faker.Random.Int(0, 9),
		_faker.Random.Int(0, 9));

	private IReadOnlyCollection<Item> GenerateItems() => _faker.Make(
		_faker.Random.Int(1, 20),
		GenerateItem)
		.ToArray();

	private Item GenerateItem() => new(
		_faker.Lorem.Word(),
		GeneratePrice(),
		_faker.Random.Int(1, 20));

	private Money GeneratePrice() => new(
		_faker.Random.Int(0, 100),
		_faker.Random.Int(0, 9),
		_faker.Random.Int(0, 9));
}

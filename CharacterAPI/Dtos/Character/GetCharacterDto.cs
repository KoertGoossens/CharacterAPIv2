using CharacterAPI.Models;

namespace CharacterAPI.Dtos
{
	public class GetCharacterDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = "Frodo";
		public int Strength { get; set; } = 10;

		public Backpack Backpack { get; set; }

		public List<Weapon> Weapons { get; set; }

		public List<Faction> Factions { get; set; }
	}
}

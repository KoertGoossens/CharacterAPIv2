using CharacterAPI.Models;

namespace CharacterAPI.Dtos
{
	public class AddCharacterDto
	{
		public string Name { get; set; } = "Frodo";
		public int Strength { get; set; } = 10;

		public AddBackpackDto Backpack { get; set; }

		public List<AddWeaponDto> Weapons { get; set; }

		public List<AddFactionDto> Factions { get; set; }
	}
}

using CharacterAPI.Models;

namespace CharacterAPI.Dtos
{
	public class UpdateCharacterDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = "Frodo";
		public int Strength { get; set; } = 10;
	}
}

using System.Text.Json.Serialization;

namespace CharacterAPI.Models
{
	public class Faction
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public List<Character> Characters { get; set; }
	}
}

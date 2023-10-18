using CharacterAPI.Data;
using CharacterAPI.Models;

namespace DataSeeder.Seeders
{
	internal class CharacterSeeder
	{
        public static async Task SeedPersons(DataContext dataContext)
        {
            var Characters = new List<Character>
            {
                new Character
                {
                    Name = "John",
                    Strength = 30,
                    Defense = 10,
                    Backpack = new Backpack
                    {
                        Name = "John Backpack"
                    },
                    Weapons = new List<Weapon>
                    {
                        new Weapon
                        {
                            Name = "John Weapon 1"
                        },
                        new Weapon
                        {
                            Name = "John Weapon 2"
                        }
                    },
                    Factions = new List<Faction>
                    {
                        new Faction
                        {
                            Name = "John Faction 1"
                        },
                        new Faction
                        {
                            Name = "John Faction 2"
                        }
                    }
                },
                new Character
                {
                    Name = "Mary",
                    Strength = 20,
                    Defense = 20,
                    Backpack = new Backpack
                    {
                        Name = "Mary Backpack"
                    },
                    Weapons = new List<Weapon>
                    {
                        new Weapon
                        {
                            Name = "Mary Weapon 1"
                        },
                        new Weapon
                        {
                            Name = "Mary Weapon 2"
                        }
                    },
                    Factions = new List<Faction>
                    {
                        new Faction
                        {
                            Name = "Mary Faction 1"
                        },
                        new Faction
                        {
                            Name = "Mary Faction 2"
                        }
                    }
                },
                new Character
                {
                    Name = "Peter",
                    Strength = 10,
                    Defense = 30,
                    Backpack = new Backpack
                    {
                        Name = "Peter Backpack"
                    },
                    Weapons = new List<Weapon>
                    {
                        new Weapon
                        {
                            Name = "Peter Weapon 1"
                        },
                        new Weapon
                        {
                            Name = "Peter Weapon 2"
                        }
                    },
                    Factions = new List<Faction>
                    {
                        new Faction
                        {
                            Name = "Peter Faction 1"
                        },
                        new Faction
                        {
                            Name = "Peter Faction 2"
                        }
                    }
                }
            };

            await dataContext.Characters.AddRangeAsync(Characters).ConfigureAwait(false);
            await dataContext.SaveChangesAsync();
        }
    }
}

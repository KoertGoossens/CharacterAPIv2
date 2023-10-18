using AutoMapper;
using CharacterAPI.Data;
using CharacterAPI.Dtos;
using CharacterAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CharacterAPI.Services.CharacterService
{
	public class CharacterService : ICharacterService
	{
		private readonly IMapper _mapper;
		private readonly DataContext _context;

		public CharacterService(IMapper mapper, DataContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
			var character = await _context.Characters.ToListAsync();
			serviceResponse.Data = character.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
		{
			var serviceResponse = new ServiceResponse<GetCharacterDto>();

			var character = await _context.Characters
				.Include(c => c.Backpack)
				.Include(c => c.Weapons)
				.Include(c => c.Factions)
				.FirstOrDefaultAsync(c => c.Id == id);

			serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto request)
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

			var newCharacter = new Character
			{
				Name = request.Name
			};

			var backpack = new Backpack
			{
				Name = request.Backpack.Name
			};

			var weapons = request.Weapons.Select(w => new Weapon
			{
				Name = w.Name
			}).ToList();

			var factions = request.Factions.Select(f => new Faction
			{
				Name = f.Name
			}).ToList();

			newCharacter.Backpack = backpack;
			newCharacter.Weapons = weapons;
			newCharacter.Factions = factions;

			var character = _mapper.Map<Character>(newCharacter);
			_context.Characters.Add(character);
			await _context.SaveChangesAsync();

			serviceResponse.Data = await _context.Characters
				.Include(c => c.Backpack)
				.Include(c => c.Weapons)
				.Include(c => c.Factions)
				.Select(c => _mapper.Map<GetCharacterDto>(c))
				.ToListAsync();

			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
		{
			var serviceResponse = new ServiceResponse<GetCharacterDto>();

			try
			{
				var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);

				if (character == null)
				{
					throw new Exception($"Character with Id '{updatedCharacter.Id}' not found.");
				}

				character.Name = updatedCharacter.Name;
				character.Strength = updatedCharacter.Strength;

				await _context.SaveChangesAsync();
				serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
			}
			catch (Exception ex)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = ex.Message;
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

			try
			{
				var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);

				if (character == null)
				{
					throw new Exception($"Character with Id '{id}' not found.");
				}

				_context.Characters.Remove(character);
				await _context.SaveChangesAsync();
				serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
			}
			catch (Exception ex)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = ex.Message;
			}

			return serviceResponse;
		}
	}
}

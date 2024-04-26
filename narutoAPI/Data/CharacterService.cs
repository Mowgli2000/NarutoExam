using System.Data.Common;
using System.Net.Http.Json;
using narutoAPI.Data;

namespace CharacterServices.Services
{
    public class CharacterService
    {
		public List<Character> favorites { get; set; } = new List<Character>();

        public async Task<List<Character>> GetCharInfo()
        {
            try
            {
                HttpClient client = new HttpClient();
                
                var response = await client.GetFromJsonAsync<CharResponse>("https://narutodb.xyz/api/character?page=1&limit=50");//1431
                return response?.Characters ?? new List<Character>();
            }
			catch (HttpRequestException e)
			{
				Console.WriteLine(e.Message);
                return new List<Character>();
			}
        }

        public List<Character> GetFavorites()
        {
            return favorites;
        }

        public void ToggleFavorite(Character character)
        {
            if (favorites.Exists(x => x.id == character.id))
            {
                favorites.Remove(new Character() { id = character.id});
            }
            else
            {
                favorites.Add(character);
            }
        }

        public bool IsFavorite(Character character)
        {
            if (favorites.Exists(x => x.id == character.id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Rate(Character character, int rating)
        {
            if (favorites.Exists(x => x.id == character.id))
            {
                character.rating = rating;
            }
        }
    }
}
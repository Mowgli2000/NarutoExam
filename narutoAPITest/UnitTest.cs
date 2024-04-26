using CharacterServices.Services;
using narutoAPI.Data;

namespace CharacterServices.UnitTests
{
    public class CharacterServicesTests
    {
        [Fact]
        public void ToggleFavorite_AddAndRemoveFavorite()
        {
            // Arrange
            var characterService = new CharacterService();
            Character character = new Character(){id = 5};

            // Act
            characterService.ToggleFavorite(character);

            // Assert
            var expected = new List<Character>(){character};
            var favorites = characterService.GetFavorites();
            Assert.Equal(favorites, expected);

            // Act
            characterService.ToggleFavorite(character);

            // Assert
            expected = new List<Character>();
            favorites = characterService.GetFavorites();
            Assert.Equal(favorites, expected);
        }
    }
}

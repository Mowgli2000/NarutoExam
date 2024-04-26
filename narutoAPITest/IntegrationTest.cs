using CharacterServices.Services;
using Microsoft.Extensions.DependencyInjection;
using Bunit;

namespace CharacterServices.IntegrationTests
{
	public class IntegrationTest
	{
		TestContext ctx = new TestContext();

		[Fact]
		public async Task TestLoadCharList()
		{
			//Arrange
			var charService = new CharacterService();
			ctx.Services.AddSingleton(charService);
			var page = ctx.RenderComponent<narutoAPI.Pages.Index>();

			//Act
			await Task.Delay(5000);
			page.Render();

			//Assert
			var listCount = page.FindAll("li").Count();
			Assert.True(listCount > 10);
		}
	}
}

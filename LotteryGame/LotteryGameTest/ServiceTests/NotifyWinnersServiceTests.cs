using LotteryGame.Dtos;
using LotteryGame.Enums;
using LotteryGame.Services;

namespace LotteryGameTest.ServiceTests
{
    public class NotifyWinnersServiceTests
    {
        [Fact]
        public void NotifyWinners_ShouldDisplayWinnersInCorrectOrder()
        {
            // Arrange
            var winners = new List<WinnersDto>
        {
            new WinnersDto(Guid.NewGuid(), "Player 1", Guid.NewGuid(), PrizeType.GrandPrize, 50.00m),
            new WinnersDto(Guid.NewGuid(), "Player 2", Guid.NewGuid(), PrizeType.SecondTier, 10.00m)
        };
            var notifyWinnersService = new NotifyWinnersService();

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            notifyWinnersService.NotifyWinners(winners, 100);

            // Assert
            var consoleOutput = output.ToString();
            Assert.Contains("Player 1", consoleOutput);
            Assert.Contains("Player 2", consoleOutput);
            Assert.Contains("Grand Prize", consoleOutput);
            Assert.Contains("Second Tier", consoleOutput);
            Assert.Contains("House Revenue", consoleOutput);
            Assert.True(consoleOutput.IndexOf("Player 1") < consoleOutput.IndexOf("Player 2"));
        }
    }
}

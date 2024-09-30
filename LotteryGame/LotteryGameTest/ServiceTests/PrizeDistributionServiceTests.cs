using Moq;
using LotteryGame.Models;
using LotteryGame.Services;

namespace LotteryGameTest.ServiceTests
{
    public class PrizeDistributionServiceTests
    {
        [Fact]
        public void DistributePrizes_ShouldReturnWinnersWithPrizes()
        {
            // Arrange
            var players = new List<Player>
        {
            new Player(Guid.NewGuid(), "Player 1", true) { Balance = 10.00m },
            new Player(Guid.NewGuid(), "Player 2", false) { Balance = 10.00m }
        };

            foreach (var player in players)
            {
                for (int i = 0; i < 5; i++)
                {
                    player.Tickets.Add(new Ticket(Guid.NewGuid(), player.Id, 1.00m));
                }
            }

            var prizeDistributionService = new PrizeDistributionService();
            int totalRevenue = 10;

            // Act
            var winners = prizeDistributionService.DistributePrizes(players, totalRevenue);

            // Assert
            Assert.NotEmpty(winners);  
            Assert.Contains(winners, w => w.PlayerName == "Player 1" || w.PlayerName == "Player 2");
        }
    }
}

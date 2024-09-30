using LotteryGame.Dtos;
using LotteryGame.Enums;
using LotteryGame.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGameTest.ServiceTests
{
    public class ConsoleNotifcationFormatterTest
    {
        [Fact]
        public void FormatWinners_ShouldReturnFormattedMessage()
        {
            // Arrange
            var formatter = new ConsoleNotificationFormatter();
            var winners = new List<WinnersDto>
            {
                new WinnersDto(Guid.NewGuid(), "Player 1", Guid.NewGuid(), PrizeType.GrandPrize, 50.00m),
                new WinnersDto(Guid.NewGuid(), "Player 2", Guid.NewGuid(), PrizeType.SecondTier, 10.00m)
            };

            // Act
            string result = formatter.FormatWinners(winners, 100.00m);

            // Assert
            Assert.Contains("Grand Prize: Player 1 wins $50.00!", result);
            Assert.Contains("Second Tier: Players: Player 2 win $10.00 each!", result);
            Assert.Contains("House Revenue: $100.00", result);
        }
    }
}

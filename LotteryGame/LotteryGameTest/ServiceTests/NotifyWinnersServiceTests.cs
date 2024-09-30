using LotteryGame.Dtos;
using LotteryGame.Enums;
using LotteryGame.Formatters;
using LotteryGame.Interfaces;
using LotteryGame.Services;
using Moq;

namespace LotteryGameTest.ServiceTests
{
    public class NotifyWinnersServiceTests
    {
        [Fact]
        public void NotifyWinners_ShouldCallOutputServiceWithFormattedMessage()
        {
            // Arrange
            var mockOutputService = new Mock<IOutputService>();
            var mockFormatter = new Mock<INotificationFormatter>();
            mockFormatter.Setup(f => f.FormatWinners(It.IsAny<List<WinnersDto>>(), It.IsAny<decimal>()))
                .Returns("Formatted winners message");

            var notifyWinnersService = new NotifyWinnersService(mockOutputService.Object, mockFormatter.Object);
            var winners = new List<WinnersDto>();  // Empty list for this example

            // Act
            notifyWinnersService.NotifyWinners(winners, 100.00m);

            // Assert
            mockOutputService.Verify(o => o.WriteMessage("Formatted winners message"), Times.Once);
        }

    }
}

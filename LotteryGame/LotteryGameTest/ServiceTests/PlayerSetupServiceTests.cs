using LotteryGame.Services;

namespace LotteryGameTest.ServiceTests
{
    public class PlayerSetupServiceTests
    {
        [Fact]
        public void InitializePlayers_ShouldReturnCorrectNumberOfPlayers()
        {
            // Arrange
            var playerSetupService = new PlayerSetupService();

            // Act
            var players = playerSetupService.InitializePlayers();

            // Assert
            var humanPlayer = players[0];
            Assert.True(humanPlayer.IsHuman, "The first player should be human.");

            int cpuPlayersCount = players.Count - 1;  //Subtract 1 for the human player
            Assert.InRange(cpuPlayersCount, 9, 14);

            Assert.InRange(players.Count, 10, 15);
        }
    }
}
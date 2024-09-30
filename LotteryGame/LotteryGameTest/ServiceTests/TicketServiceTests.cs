using LotteryGame.Models;
using LotteryGame.Services;

namespace LotteryGameTest.ServiceTests
{
    public class TicketServiceTests
    {
        [Fact]
        public void HandleTicketPurchase_ShouldAddTicketsToPlayer()
        {
            // Arrange
            var humanPlayer = new Player(Guid.NewGuid(), "Human Player", true);  
            var cpuPlayer1 = new Player(Guid.NewGuid(), "CPU Player 1", false);  
            var cpuPlayer2 = new Player(Guid.NewGuid(), "CPU Player 2", false);  

            var players = new List<Player> { humanPlayer, cpuPlayer1, cpuPlayer2 };
            var ticketService = new TicketService();

           
            var inputReader = new StringReader("5");
            Console.SetIn(inputReader);

            // Act
            ticketService.HandleTicketPurchase(players);

            // Assert
            Assert.Equal(5, humanPlayer.Tickets.Count);  
            Assert.True(cpuPlayer1.Tickets.Count > 0);   
            Assert.True(cpuPlayer2.Tickets.Count > 0);   
        }
    }
}
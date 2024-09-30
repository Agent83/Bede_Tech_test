using LotteryGame.Dtos;
using LotteryGame.Interfaces;
using LotteryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Services
{
    public class LotteryService: ILotteryService
    {
        private readonly IPlayerSetupService _playerSetupService;
        private readonly ITicketService _ticketService;
        private readonly IPrizeDistributionService _prizeDistributionService;
        private readonly INotifyWinnersService _notifyWinnersService;

        public LotteryService(IPlayerSetupService playerSetupService, ITicketService ticketService, 
                              IPrizeDistributionService prizeDistributionService, INotifyWinnersService notifyWinnersService)
        {
            _playerSetupService = playerSetupService;
            _ticketService = ticketService;
            _prizeDistributionService = prizeDistributionService;
            _notifyWinnersService = notifyWinnersService;
        }

        public void RunLottery()
        {
            var players = GetPlayers();
            decimal ticketPrice = 1.00m; 
            var humanPlayer = players[0];
            DisplayWelcomeMessage(humanPlayer, ticketPrice);

            _ticketService.HandleTicketPurchase(players);

            DisplayCpuPlayersMessage(players);

            int totalRevenue = players.Sum(p => p.Tickets.Count);

            List<WinnersDto> winners = _prizeDistributionService.DistributePrizes(players, totalRevenue);

            _notifyWinnersService.NotifyWinners(winners, totalRevenue);
        }
        private List<Player> GetPlayers()
        {
            return _playerSetupService.InitializePlayers();
        }
        public void DisplayWelcomeMessage(Player player, decimal ticketPrice)
        {
            Console.WriteLine($"Welcome to the Bede Lottery, {player.Name}!\n");
            Console.WriteLine($"* Your digital balance: ${player.Balance}");
            Console.WriteLine($"* Ticket Price: ${ticketPrice} each\n");
        }
        public static void DisplayCpuPlayersMessage(List<Player> players)
        {
            int cpuCount = players.Count - 1;
            Console.WriteLine($"\n{cpuCount} other CPU players also purchased tickets\n");
        }
    }
}

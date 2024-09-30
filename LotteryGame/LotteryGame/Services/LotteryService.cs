using LotteryGame.Dtos;
using LotteryGame.Formatters;
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
        private readonly IOutputService _outputService;
        private readonly WelcomeAndCpuPlayersFormatter _formatter;

        public LotteryService(IPlayerSetupService playerSetupService,
                              ITicketService ticketService, 
                              IPrizeDistributionService prizeDistributionService, 
                              INotifyWinnersService notifyWinnersService,
                              IOutputService outputService,
                              WelcomeAndCpuPlayersFormatter formatter)
        {
            _playerSetupService = playerSetupService;
            _ticketService = ticketService;
            _prizeDistributionService = prizeDistributionService;
            _notifyWinnersService = notifyWinnersService;
            _outputService = outputService;
            _formatter = formatter;

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
            var message = _formatter.FormatWelcomeMessage(player, ticketPrice);
            _outputService.WriteMessage(message);
        }
        public void DisplayCpuPlayersMessage(List<Player> players)
        {
           var message = _formatter.FormatCpuPlayersMessage(players);
           _outputService.WriteMessage(message);   
        }
    }
}

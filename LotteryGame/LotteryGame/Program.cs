using LotteryGame.Formatters;
using LotteryGame.Interfaces;
using LotteryGame.Models;
using LotteryGame.Services;
using System;
using System.Collections.Generic;

namespace LotteryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOutputService outputService = new ConsoleOutputService();
            var welcomeFormatter = new WelcomeAndCpuPlayersFormatter();

            IPlayerSetupService playerSetupService = new PlayerSetupService();
            ITicketService ticketService = new TicketService();
            IPrizeDistributionService prizeDistributionService = new PrizeDistributionService();
            INotifyWinnersService notifyWinnersService = new NotifyWinnersService(outputService, new ConsoleNotificationFormatter());

            ILotteryService lotteryService = new LotteryService(
                playerSetupService,
                ticketService,
                prizeDistributionService,
                notifyWinnersService,
                outputService,
                welcomeFormatter
            );

            lotteryService.RunLottery();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}

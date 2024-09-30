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
           
            IPlayerSetupService playerSetupService = new PlayerSetupService();
            ITicketService ticketService = new TicketService();
            IPrizeDistributionService prizeDistributionService = new PrizeDistributionService();
            INotifyWinnersService notifyWinnersService = new NotifyWinnersService();

            ILotteryService lotteryService = new LotteryService(
                playerSetupService,
                ticketService,
                prizeDistributionService,
                notifyWinnersService
            );

            lotteryService.RunLottery();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}

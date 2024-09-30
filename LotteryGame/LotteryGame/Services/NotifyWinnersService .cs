using LotteryGame.Dtos;
using LotteryGame.Enums;
using LotteryGame.Interfaces;
using LotteryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Services
{
    public class NotifyWinnersService : INotifyWinnersService
    {
        public void NotifyWinners(List<WinnersDto> winnersList, int totalRevenue)
        {
            var grandPrizeWinners = winnersList.Where(w => w.Prize == PrizeType.GrandPrize).ToList();
            var secondTierWinners = winnersList.Where(w => w.Prize == PrizeType.SecondTier).ToList();
            var thirdTierWinners = winnersList.Where(w => w.Prize == PrizeType.ThirdTier).ToList();

            Console.WriteLine("Ticket Draw Results:\n");

            if (grandPrizeWinners.Any())
            {
                foreach (var winner in grandPrizeWinners)
                {
                    Console.WriteLine($"* Grand Prize: {winner.PlayerName} wins ${winner.PrizeAmount:0.00}!");
                }
            }

            if (secondTierWinners.Any())
            {
                var secondTierPlayerNames = secondTierWinners.Select(w => w.PlayerName).Distinct();
                Console.WriteLine($"* Second Tier: Players {string.Join(", ", secondTierPlayerNames)} win ${secondTierWinners.First().PrizeAmount:0.00} each!");
            }

            if (thirdTierWinners.Any())
            {
                var thirdTierPlayerNames = thirdTierWinners.Select(w => w.PlayerName).Distinct();
                Console.WriteLine($"* Third Tier: Players {string.Join(", ", thirdTierPlayerNames)} win ${thirdTierWinners.First().PrizeAmount:0.00} each!");
            }

            var totalWinnings = winnersList.Sum(w => w.PrizeAmount);

            var houseProfit = totalRevenue - totalWinnings;
            Console.WriteLine("\nCongratulations to the winners");
            Console.WriteLine($"\nHouse Revenue: ${houseProfit:0.00}");
        }
    }
}
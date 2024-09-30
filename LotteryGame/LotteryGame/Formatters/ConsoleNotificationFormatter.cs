using LotteryGame.Dtos;
using LotteryGame.Enums;
using LotteryGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Formatters
{
    public class ConsoleNotificationFormatter: INotificationFormatter
    {
        public string FormatWinners(List<WinnersDto> winners, decimal houseProfit)
        {
            var result = new StringBuilder();
            result.AppendLine("Ticket Draw Results:");

            var grandPrizeWinner = winners.FirstOrDefault(w => w.PrizeType == PrizeType.GrandPrize);
            var secondTierWinners = winners.Where(w => w.PrizeType == PrizeType.SecondTier).ToList();
            var thirdTierWinners = winners.Where(w => w.PrizeType == PrizeType.ThirdTier).ToList();

            if (grandPrizeWinner != null)
            {
                result.AppendLine($"\n* Grand Prize: {grandPrizeWinner.PlayerName} wins ${grandPrizeWinner.PrizeAmount}!");
            }

            if (secondTierWinners.Any())
            {
                var secondTierGroups = secondTierWinners
                    .GroupBy(w => w.PrizeAmount)
                    .Select(g => $"Players: {string.Join(", ", g.Select(w => w.PlayerName))} win ${g.Key} each!");
                foreach (var group in secondTierGroups)
                {
                    result.AppendLine($"* Second Tier: {group}");
                }
            }

            if (thirdTierWinners.Any())
            {
                var thirdTierGroups = thirdTierWinners
                    .GroupBy(w => w.PrizeAmount)
                    .Select(g => $"Players: {string.Join(", ", g.Select(w => w.PlayerName))} win ${g.Key} each!");
                foreach (var group in thirdTierGroups)
                {
                    result.AppendLine($"* Third Tier: {group}");
                }
            }

            result.AppendLine("\nCongratulations to the winners");
            result.AppendLine($"\nHouse Revenue: ${houseProfit}");

            return result.ToString();
        }
    }
}

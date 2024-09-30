using LotteryGame.Dtos;
using LotteryGame.Enums;
using LotteryGame.Interfaces;
using LotteryGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Services
{
    public class PrizeDistributionService: IPrizeDistributionService
    {
        public List<WinnersDto> DistributePrizes(List<Player> players, int totalRevenue)
        {
            List<WinnersDto> winnersList = new List<WinnersDto>();

            int grandPrizeAmount = (int)(totalRevenue * 0.5);
            List<Ticket> eligibleTickets = GetEligibleTickets(players);

            DistributePrizeToSingleWinner(players, grandPrizeAmount, eligibleTickets, PrizeType.GrandPrize, winnersList);

            eligibleTickets = GetEligibleTickets(players); 

            int secondTierPrizeAmount = (int)(totalRevenue * 0.3);
            int numberOfSecondTierWinners = (int)Math.Round(eligibleTickets.Count * 0.1); 
            
            DistributePrizeToMultipleWinners(players, secondTierPrizeAmount, numberOfSecondTierWinners, eligibleTickets, PrizeType.SecondTier, winnersList);

            eligibleTickets = GetEligibleTickets(players);  

            int thirdTierPrizeAmount = (int)(totalRevenue * 0.1);
            int numberOfThirdTierWinners = (int)Math.Round(eligibleTickets.Count * 0.2);
            numberOfThirdTierWinners = Math.Max(numberOfThirdTierWinners, 1); 

            DistributePrizeToMultipleWinners(players, thirdTierPrizeAmount, numberOfThirdTierWinners, eligibleTickets, PrizeType.ThirdTier, winnersList);

            return winnersList;  
        }

        private void DistributePrizeToSingleWinner(List<Player> players, int prize, List<Ticket> eligibleTickets, PrizeType prizeType, List<WinnersDto> winnersList)
        {
            if (eligibleTickets.Count > 0)
            {
                var random = new Random();
                var winnerTicket = eligibleTickets[random.Next(eligibleTickets.Count)];
                var winner = players.First(p => p.Id == winnerTicket.PurchasedById);
                winner.Winnings += prize;
                winnersList.Add(new WinnersDto(winner.Id, winner.Name, winnerTicket.TicketId, prizeType, prize));
                winnerTicket.IsWinner = true;
                eligibleTickets.Remove(winnerTicket);
            }
        }

        private void DistributePrizeToMultipleWinners(List<Player> players, int prize, int numberOfWinners, List<Ticket> eligibleTickets, PrizeType prizeType, List<WinnersDto> winnersList)
        {
            var random = new Random();

            if (numberOfWinners > 0 && eligibleTickets.Count > 0)
            {
                int individualPrize = Math.Max(prize / numberOfWinners, 1);

                for (int i = 0; i < numberOfWinners && eligibleTickets.Count > 0; i++)
                {
                    var winnerTicket = eligibleTickets[random.Next(eligibleTickets.Count)];
                    var winner = players.First(p => p.Id == winnerTicket.PurchasedById);

                    winner.Winnings += individualPrize;
                    winnersList.Add(new WinnersDto(winner.Id, winner.Name, winnerTicket.TicketId, prizeType, individualPrize));

                    winnerTicket.IsWinner = true;
                    eligibleTickets.Remove(winnerTicket);
                }
            }
        }
        private List<Ticket> GetEligibleTickets(List<Player> players)
        {
            return players.SelectMany(p => p.Tickets)
                          .Where(t => !t.IsWinner)
                          .ToList();
        }
    }
}

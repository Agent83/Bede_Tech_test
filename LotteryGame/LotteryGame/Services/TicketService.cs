using LotteryGame.Interfaces;
using LotteryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Services
{
    public class TicketService : ITicketService
    {
        public void HandleTicketPurchase(List<Player> players)
        {

            Console.WriteLine("How many tickets would you like to purchase?");
            int tickets;

            while (!int.TryParse(Console.ReadLine(), out tickets) || tickets < 1 || tickets > 10)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
            }

            BuyTickets(players[0], tickets);

            Random random = new Random();
            for (int i = 1; i < players.Count; i++)
            {
                int randomTickets = random.Next(1, 11);
                BuyTickets(players[i], randomTickets);
            }
        }

        public void BuyTickets(Player player, int numberOfTickets)
        {
            decimal ticketPrice = 1.00m; 

            int maxTickets = Math.Min((int)(player.Balance / ticketPrice), numberOfTickets);

            for (int i = 0; i < maxTickets; i++)
            {
           
                player.Tickets.Add(new Ticket(Guid.NewGuid(), player.Id, ticketPrice));
            }

            player.Balance -= maxTickets * ticketPrice;
        }
    }
}

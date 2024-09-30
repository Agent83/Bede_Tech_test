using LotteryGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Models
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public Guid PurchasedById { get; set; }
        public bool IsWinner { get; set; }
        public PrizeType? PrizeWon { get; set; }
        public decimal TicketPrice { get; set; }  

        public Ticket(Guid ticketId, Guid purchasedById, decimal ticketPrice = 1.00m)
        {
            TicketId = ticketId; 
            PurchasedById = purchasedById;
            IsWinner = false;
            TicketPrice = ticketPrice;
        }
    }
}

using LotteryGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Dtos
{
    public class WinnersDto
    {
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public Guid TicketId { get; set; }
        public PrizeType PrizeType { get; set; }
        public decimal PrizeAmount { get; set; }

        public WinnersDto(Guid playerId, string playerName, Guid ticketId, PrizeType prizeType, decimal prizeAmount)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            TicketId = ticketId;
            PrizeType = prizeType;
            PrizeAmount = prizeAmount;
        }
    }
}

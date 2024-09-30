using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<Ticket> Tickets { get; set; }
        public bool IsHuman { get; set; }
        public decimal Winnings { get; set; }

        public Player(Guid id, string name, bool isHuman)
        {
            Id = id;
            Name = name;
            IsHuman = isHuman;
            Tickets = new List<Ticket>();
            Balance = 10.00m;
            Winnings = 0;
        }

    }
}

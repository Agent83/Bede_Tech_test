using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Interfaces
{
    public interface ITicketService
    {
        public void HandleTicketPurchase(List<Models.Player> players);
    }
}

using LotteryGame.Dtos;
using LotteryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Interfaces
{
    public interface INotifyWinnersService
    {
        void NotifyWinners(List<WinnersDto> winnersList, int totalRevenue);
    }
}

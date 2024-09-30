using LotteryGame.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Interfaces
{
    public interface INotificationFormatter
    {
        string FormatWinners(List<WinnersDto> winners, decimal houseProfit);
    }
}

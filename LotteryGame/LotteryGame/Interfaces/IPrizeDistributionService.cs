using LotteryGame.Dtos;
using LotteryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Interfaces
{
    public interface IPrizeDistributionService
    {
        public List<WinnersDto> DistributePrizes(List<Player> players, int totalRevenue);
    }
}

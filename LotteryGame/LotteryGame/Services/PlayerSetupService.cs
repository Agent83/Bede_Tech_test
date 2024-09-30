using LotteryGame.Interfaces;
using LotteryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Services
{
    public class PlayerSetupService : IPlayerSetupService
    {
        public List<Player> InitializePlayers()
        {
            var players = new List<Player>();

            players.Add(new Player(Guid.NewGuid(), "Player 1",true));

            Random random = new Random();
            int cpuPlayerCount = random.Next(10, 16);

            for (int i = 2; i < cpuPlayerCount + 1; i++)
            {
                players.Add(new Player(Guid.NewGuid(), $"Player {i}",false));
            }

            return players;
        }
    }
}

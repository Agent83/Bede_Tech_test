using LotteryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Formatters
{
    public class WelcomeAndCpuPlayersFormatter
    {
        public string FormatWelcomeMessage(Player player, decimal ticketPrice)
        {
            return $"Welcome to the Bede Lottery, {player.Name}!\n" +
                   $"* Your digital balance: ${player.Balance}\n" +
                   $"* Ticket Price: ${ticketPrice} each\n";
        }

        public string FormatCpuPlayersMessage(List<Player> players)
        {
            int cpuCount = players.Count - 1;
            return $"\n{cpuCount} other CPU players also purchased tickets\n";
        }
    }
}

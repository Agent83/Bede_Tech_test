using LotteryGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Services
{
    public class ConsoleOutputService : IOutputService
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}

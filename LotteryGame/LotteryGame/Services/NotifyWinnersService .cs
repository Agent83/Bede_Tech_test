using LotteryGame.Dtos;
using LotteryGame.Enums;
using LotteryGame.Formatters;
using LotteryGame.Interfaces;
using LotteryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Services
{
    public class NotifyWinnersService: INotifyWinnersService
    {
        private readonly IOutputService _outputService;
        private readonly INotificationFormatter _notificationFormatter;
        public NotifyWinnersService(IOutputService outputService, INotificationFormatter notificationFormatter) 
        {
           _outputService = outputService;
           _notificationFormatter = notificationFormatter;
        }
        public void NotifyWinners(List<WinnersDto> winners, decimal houseProfit)
        {
           string message = _notificationFormatter.FormatWinners(winners, houseProfit);

           _outputService.WriteMessage(message);
        }

    }
}
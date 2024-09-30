using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryGame.Enums
{
    public enum PrizeType
    {
        [Description("Grand Prize")]
        GrandPrize,

        [Description("Second Tier")]
        SecondTier,

        [Description("Third Tier")]
        ThirdTier
    }
}

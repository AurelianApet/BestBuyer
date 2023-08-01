using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBot.Model
{
    public class CardInfo
    {
        public string cardNo { get; set; }
        public string expires { get; set; }
        public string security { get; set; }

        public CardInfo()
        {
            cardNo = string.Empty;
            expires = string.Empty;
            security = string.Empty;
        }

        public CardInfo(CardInfo cardInfo)
        {
            cardNo = cardInfo.cardNo;
            expires = cardInfo.expires;
            security = cardInfo.security;
        }
    }
}

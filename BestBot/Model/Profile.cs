using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBot.Model
{
    public class Profile
    {
        public string profileName { get; set; }
        public CardInfo cardInfo { get; set; }
        public DeliveryInfo deliveryInfo { get; set; }

        public Profile()
        {
            profileName = string.Empty;
            cardInfo = new CardInfo();
            deliveryInfo = new DeliveryInfo();
        }

        public Profile(Profile profile)
        {
            profileName = profile.profileName;
            cardInfo = new CardInfo(profile.cardInfo);
            deliveryInfo = new DeliveryInfo(profile.deliveryInfo);
        }
    }
}

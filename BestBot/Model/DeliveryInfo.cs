using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBot.Model
{
    public class DeliveryInfo
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int state { get; set; }
        public string zipCode { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }

        public DeliveryInfo()
        {
            firstName = string.Empty;
            lastName = string.Empty;
            address = string.Empty;
            city = string.Empty;
            state = -1;
            zipCode = string.Empty;
            phone = string.Empty;
            email = string.Empty;
            birthday = string.Empty;
        }

        public DeliveryInfo(DeliveryInfo deliveryInfo)
        {
            firstName = deliveryInfo.firstName;
            lastName = deliveryInfo.lastName;
            address = deliveryInfo.address;
            city = deliveryInfo.city;
            state = deliveryInfo.state;
            zipCode = deliveryInfo.zipCode;
            phone = deliveryInfo.phone;
            email = deliveryInfo.email;
            birthday = deliveryInfo.birthday;
        }
    }
}

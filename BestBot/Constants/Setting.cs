using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BestBot.Model;

namespace BestBot.Constants
{
    public class Setting
    {
        private static Setting _instance = null;

        public static Setting instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Setting();

                return _instance;
            }
        }

        //product url
        public string productUrl { get; set; }
        public string size { get; set; }

        //deathbycaptcha
        public string captchaKey { get; set; }
        public int interval { get; set; }       

        //Card
        public string cardNo { get; set; }
        public string expires { get; set; }
        public string security { get; set; }

        //Delivery
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int state { get; set; }
        public string zipCode { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }

        //Setting
        public decimal threadCount { get; set; }
        public bool useProxy { get; set; }
        public string proxyPath { get; set; }
        public List<HttpsProxy> proxyList { get; set; }

        public Setting()
        {
            productUrl = string.Empty;
            size = string.Empty;

            captchaKey = string.Empty;
            interval = 1000;

            cardNo = string.Empty;
            expires = string.Empty;
            security = string.Empty;

            firstName = string.Empty;
            lastName = string.Empty;
            address = string.Empty;
            city = string.Empty;
            state = -1;
            zipCode = string.Empty;
            phoneNumber = string.Empty;
            email = string.Empty;
            birthday = string.Empty;

            threadCount = 1;
            useProxy = true;
            proxyPath = string.Empty;
            proxyList = new List<HttpsProxy>();
        }
    }
}

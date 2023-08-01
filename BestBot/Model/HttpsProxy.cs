using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBot.Model
{
    public class HttpsProxy
    {
        public HttpsProxy(string strIP, string nPort, string cId, string cPass)
        {
            _strIP = strIP;
            _nPort = nPort;
            _cId = cId;
            _cPass = cPass;
        }

        public HttpsProxy(string strIP, string nPort)
        {
            _strIP = strIP;
            _nPort = nPort;
        }

        public string _strIP;
        public string _nPort;
        public string _cId;
        public string _cPass;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBot.Model
{
    public class TaskInfo
    {
        public string productUrl { get; set; }
        public string size { get; set; }
        public string profileName { get; set; }
        public Profile profile { get; set; }
        public HttpsProxy proxy { get; set; }
        public bool autoCheckout { get; set; }
        public bool backdoor { get; set; }
        public string backdoorInfo { get; set; }
        
        public TaskInfo()
        {
            productUrl = string.Empty;
            size = string.Empty;
            profileName = string.Empty;
            profile = new Profile();
            proxy = null;
            autoCheckout = false;
            backdoor = false;
            backdoorInfo = string.Empty;
        }

        public TaskInfo(TaskInfo taskInfo)
        {
            productUrl = taskInfo.productUrl;
            size = taskInfo.size;
            profileName = taskInfo.profileName;
            profile = new Profile(taskInfo.profile);
            proxy = taskInfo.proxy;
            autoCheckout = taskInfo.autoCheckout;
            backdoor = taskInfo.backdoor;
            backdoorInfo = taskInfo.backdoorInfo;
        }
    }
}

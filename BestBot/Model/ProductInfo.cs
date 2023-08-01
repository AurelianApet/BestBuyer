using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBot.Model
{
    public class ProductInfo
    {
        public string productUrl { get; set; }
        public string size { get; set; }

        public ProductInfo()
        {
            productUrl = string.Empty;
            size = string.Empty;
        }
    }
}

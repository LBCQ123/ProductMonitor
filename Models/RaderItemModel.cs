using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    public class RaderItemModel
    {

        public string ItemName { get; set; }

        public double Value { get; set; }

        public RaderItemModel(string itemName,double value)
        {
            ItemName = itemName;
            Value = value;
        }

    }
}

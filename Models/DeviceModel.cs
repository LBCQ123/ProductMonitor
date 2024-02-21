using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    public class DeviceModel
    {
        /// <summary>
        /// 监控项名称
        /// </summary>
        public string DeviceItem { get; set; }

        /// <summary>
        /// 监控值
        /// </summary>
        public double Value { get; set; }

        public DeviceModel(string itemName,double value)
        {
            DeviceItem = itemName;
            Value = value;
        }

    }
}

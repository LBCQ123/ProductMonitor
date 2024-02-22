using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    public class StaffOutWorkModel
    {
        public string StaffName { get; set; }

        public string StaffPosition { get; set; }


        public int OutWorkCount { get; set; }

        public int DisplayWidth
        {
            get
            {
                return OutWorkCount * 45 / 100;
            }
        }

        public StaffOutWorkModel(string name,string position,int outWorkCount)
        {
            StaffName = name;
            StaffPosition = position;
            OutWorkCount = outWorkCount;
        }

    }
}

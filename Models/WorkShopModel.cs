using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    public class WorkShopModel
    {

        public WorkShopModel(string workShopName,int workingCount,int waitingCount,int wrongingCount,int stopingCount)
        {
            WorkShopName = workShopName;
            WorkingCount = workingCount;
            WaitingCount = waitingCount;
            WrongingCount = wrongingCount;
            StopingCount = stopingCount;
        }

        /// <summary>
        /// 车间名称
        /// </summary>
        public string WorkShopName { get; set; }

        /// <summary>
        /// 工作台数
        /// </summary>
        public int WorkingCount { get; set; }

        /// <summary>
        /// 等待台数
        /// </summary>
        public int WaitingCount { get; set; }

        /// <summary>
        /// 故障台数
        /// </summary>
        public int WrongingCount { get; set; }

        /// <summary>
        /// 停机台数
        /// </summary>
        public int StopingCount { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount
        {
            get
            {
                return WorkingCount + WaitingCount + WrongingCount + StopingCount;
            }
        }
    }
}

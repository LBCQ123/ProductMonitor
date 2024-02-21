using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    public class AlarmModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Num { get; set; } = string.Empty;

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; } = string.Empty;

        /// <summary>
        /// 发生时间
        /// </summary>
        public string Time { get; set; } = string.Empty;

        /// <summary>
        /// 报警时长
        /// </summary>
        public int Duratuin { get; set; }


        public AlarmModel(string num,string msg,string time,int duration)
        {
            Num = num;
            Msg = msg;
            Time = time;
            Duratuin = duration;
        }

    }
}

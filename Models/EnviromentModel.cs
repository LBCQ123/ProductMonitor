using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    public class EnviromentModel
    {
        /// <summary>
        /// 测试项目的名称
        /// </summary>
        public string EnvirItemName { get; set; } = string.Empty;

        /// <summary>
        /// 测试项目的值
        /// </summary>
        public string EnvirItemValue { get; set; } = string.Empty;


        public EnviromentModel()
        {
            
        }

        public EnviromentModel(string name,string value)
        {
            EnvirItemName = name;
            EnvirItemValue = value;
        }
    }
}

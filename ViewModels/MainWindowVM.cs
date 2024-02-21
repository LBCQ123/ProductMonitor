using CommunityToolkit.Mvvm.ComponentModel;
using ProductMonitor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProductMonitor.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        private UserControl monitorUC = new UserControls.MonitorUC();



        #region MonitorUC
        /// <summary>
        /// 当前显示时间
        /// </summary>
        [ObservableProperty]
        private DateTime timeNow = DateTime.Now;

        [ObservableProperty]
        private int machineCount = 229;
        [ObservableProperty]
        private int productCount = 1643;
        [ObservableProperty]
        private int badCount = 35;

        /// <summary>
        /// 环境监控数据
        /// </summary>
        public BindingList<EnviromentModel> EnviromentList { get; set; }
        /// <summary>
        /// 报警记录
        /// </summary>
        public BindingList<AlarmModel> AlarmList { get; set; }

        public BindingList<DeviceModel> DeviceList { get; set; }

        public List<RaderItemModel> RaderList { get; set; }
        #endregion
        public MainWindowVM()
        {
            EnviromentList = new BindingList<EnviromentModel>
            {
                new EnviromentModel("光照(Lux)", "123"),
                new EnviromentModel("噪音(db)", "55"),
                new EnviromentModel("温度(℃)", "80"),
                new EnviromentModel("湿度(%)", "43"),
                new EnviromentModel("PM2.5(m3)", "26"),
                new EnviromentModel("硫化氢(PPM)", "778"),
                new EnviromentModel("氮气(PPM)", "223")
            };

            AlarmList = new BindingList<AlarmModel>()
            {
                new AlarmModel("01","设备温度过高","2023-11-23 18:34:56",7),
                new AlarmModel("02","车间温度过高","2023-11-23 18:34:56",10),
                new AlarmModel("03","设备转速过快","2023-11-23 18:34:56",12),
                new AlarmModel("04","设备气压偏低","2023-11-23 18:34:56",90)
            };

            DeviceList = new BindingList<DeviceModel>()
            {
                new DeviceModel("电能(kwh)",60.8),
                new DeviceModel("电压(V)",390),
                new DeviceModel("电流(A)",5),
                new DeviceModel("压差(kpa)",13),
                new DeviceModel("温度(℃)",36),
                new DeviceModel("振动(mm/s)",4.1),
                new DeviceModel("转速(r/min)",2600),
                new DeviceModel("气压(kpa)",0.5)
            };

            RaderList = new List<RaderItemModel>()
            {
                new RaderItemModel("排烟风机",90),
                new RaderItemModel("客梯",30),
                new RaderItemModel("供水机",34),
                new RaderItemModel("喷淋水泵",69),
                new RaderItemModel("稳压设备",20),
                new RaderItemModel("鼓风机",65)
            };


        }



    }
}

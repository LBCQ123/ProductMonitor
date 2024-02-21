using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProductMonitor.Resource.Converters
{
    public class DateCvtWeekday : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is  DateTime dt)
            {
                int index = (int)dt.DayOfWeek;
                string[] week = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"};
                return week[index];
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

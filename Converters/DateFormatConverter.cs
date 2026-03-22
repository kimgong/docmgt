using System;
using System.Globalization;
using System.Windows.Data;

namespace DocMgt.Converters
{
    /// <summary>
    /// 日期格式转换器
    /// </summary>
    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                string format = parameter as string ?? "yyyy-MM-dd HH:mm:ss";
                return ((DateTime)value).ToString(format);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime result;
            if (DateTime.TryParse(value as string, out result))
                return result;
            return value;
        }
    }
}

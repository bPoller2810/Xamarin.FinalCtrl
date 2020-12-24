using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.FinalCtrl.Sample.Enumerations;
using Xamarin.Forms;

namespace Xamarin.FinalCtrl.Sample.Converter
{
    public class TabTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ETabType tabType) { return string.Empty; }

            return tabType.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

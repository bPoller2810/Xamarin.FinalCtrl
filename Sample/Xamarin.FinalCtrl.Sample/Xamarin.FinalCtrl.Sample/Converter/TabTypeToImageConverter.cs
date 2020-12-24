using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.FinalCtrl.Sample.Enumerations;
using Xamarin.Forms;

namespace Xamarin.FinalCtrl.Sample.Converter
{
    public class TabTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ETabType tabType) { return string.Empty; }
            return tabType switch
            {
                ETabType.List => "list.png",
                ETabType.Setting => "marker.png",

                _ => throw new NotImplementedException(),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

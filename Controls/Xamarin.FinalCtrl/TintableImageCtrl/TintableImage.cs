using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.FinalCtrl
{
    public class TintableImage : Image
    {

        public static readonly BindableProperty TintColorProperty =
           BindableProperty.Create(
               nameof(TintColor),
               typeof(Color),
               typeof(TintableImage));
        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }


    }
}

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.FinalCtrl;
using Xamarin.FinalCtrl.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TintableImage), typeof(TintableImageRenderer))]
namespace Xamarin.FinalCtrl.Droid.Renderer
{
    public class TintableImageRenderer : ImageRenderer
    {

        public TintableImageRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            if (e.OldElement is TintableImage oti)
            {
                oti.PropertyChanged -= HandleImagePropertyChanged;
            }

            base.OnElementChanged(e);

            if (e.NewElement is TintableImage nti)
            {
                nti.PropertyChanged += HandleImagePropertyChanged;
                HandleImagePropertyChanged(this, new PropertyChangedEventArgs("TintColor"));
            }


        }

        private void HandleImagePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (!(Element is TintableImage xfImage)) { return; }
            if (!(Control is ImageView aImage)) { return; }

            if (args.PropertyName != "TintColor") { return; }

            var filter = new PorterDuffColorFilter(xfImage.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            aImage.SetColorFilter(filter);

        }

    }
}
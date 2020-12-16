using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.FinalCtrl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Toolbar : Grid
    {

        #region bindable

        #region bindable Text
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
                nameof(Text),
                typeof(string),
                typeof(Toolbar),
                propertyChanged: HandleTextPropertyChanged);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        private static void HandleTextPropertyChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is not Toolbar tb) { return; }
            tb._lbl.Text = (string)newValue;
        }
        #endregion

        #region bindable TextColor
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(
                nameof(TextColor),
                typeof(Color),
                typeof(Toolbar),
                propertyChanged: HandleTextColorPropertyChanged);
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        private static void HandleTextColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is not Toolbar tb) { return; }
            tb._lbl.TextColor = (Color)newValue;
        }
        #endregion

        #region bindable FontSize
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(
                nameof(FontSize),
                typeof(double),
                typeof(Toolbar),
                propertyChanged: HandleFontSizePropertyChanged);
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }
        private static void HandleFontSizePropertyChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is not Toolbar tb) { return; }
            tb._lbl.FontSize = (double)newValue;
        }
        #endregion

        #region bindable FontFamily
        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(
                nameof(FontFamily),
                typeof(string),
                typeof(Toolbar),
                propertyChanged: HandleFontFamilyPropertyChanged);
        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }
        private static void HandleFontFamilyPropertyChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is not Toolbar tb) { return; }
            tb._lbl.FontFamily = (string)newValue;
        }
        #endregion

        #region bindable LeftContent
        public static readonly BindableProperty LeftContentProperty =
            BindableProperty.Create(
                nameof(LeftContent),
                typeof(View),
                typeof(Toolbar),
                propertyChanged: HandleLeftContentPropertyChanged);
        public View LeftContent
        {
            get => (View)GetValue(LeftContentProperty);
            set => SetValue(LeftContentProperty, value);
        }
        private static void HandleLeftContentPropertyChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is not Toolbar tb) { return; }
            tb._left.Content = (View)newValue;
        }
        #endregion

        #region bindable RightContent
        public static readonly BindableProperty RightContentProperty =
            BindableProperty.Create(
                nameof(RightContent),
                typeof(View),
                typeof(Toolbar),
                propertyChanged: HandleRightContentPropertyChanged);
        public View RightContent
        {
            get => (View)GetValue(RightContentProperty);
            set => SetValue(RightContentProperty, value);
        }
        private static void HandleRightContentPropertyChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is not Toolbar tb) { return; }
            tb._right.Content = (View)newValue;
        }
        #endregion

        #region bindable LeftCommand
        public static readonly BindableProperty LeftCommandProperty =
            BindableProperty.Create(
                nameof(LeftCommand),
                typeof(ICommand),
                typeof(Toolbar));
        public ICommand LeftCommand
        {
            get => (ICommand)GetValue(LeftCommandProperty);
            set => SetValue(LeftCommandProperty, value);
        }
        #endregion

        #region bindable RightCommand
        public static readonly BindableProperty RightCommandProperty =
            BindableProperty.Create(
                nameof(RightCommand),
                typeof(ICommand),
                typeof(Toolbar));
        public ICommand RightCommand
        {
            get => (ICommand)GetValue(RightCommandProperty);
            set => SetValue(RightCommandProperty, value);
        }
        #endregion

        #region bindable LeftCommandParameter
        public static readonly BindableProperty LeftCommandParameterProperty =
            BindableProperty.Create(
                nameof(LeftCommandParameter),
                typeof(object),
                typeof(Toolbar));
        public object LeftCommandParameter
        {
            get => GetValue(LeftCommandParameterProperty);
            set => SetValue(LeftCommandParameterProperty, value);
        }
        #endregion

        #region bindable RightCommandParameter
        public static readonly BindableProperty RightCommandParameterProperty =
            BindableProperty.Create(
                nameof(RightCommandParameter),
                typeof(object),
                typeof(Toolbar));
        public object RightCommandParameter
        {
            get => GetValue(RightCommandParameterProperty);
            set => SetValue(RightCommandParameterProperty, value);
        }
        #endregion

        #endregion

        #region ctor
        public Toolbar()
        {
            InitializeComponent();
            FontSize = 16d;
        }

        #endregion

        #region event handler
        private void HandleLeftCtrlTapped(object sender, EventArgs args)
        {
            LeftCommand?.Execute(LeftCommandParameter);
        }
        private void HandleRightCtrlTapped(object sender, EventArgs args)
        {
            RightCommand?.Execute(RightCommandParameter);
        }
        #endregion


    }
}
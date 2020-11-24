namespace Xamarin.FinalCtrl.TabViewCtrl
{
    public interface ITabItem
    {
        void Appearing();
        void Disappearing();
        public bool IsSelected { get; set; }

    }

}

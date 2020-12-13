namespace Xamarin.FinalCtrl
{
    public interface ITabItem
    {
        void Appearing();
        void Disappearing();
        public bool IsSelected { get; set; }

    }

}

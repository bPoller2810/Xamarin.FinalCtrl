using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.FinalCtrl.Helper;
using Xamarin.FinalCtrl.Sample.Enumerations;

namespace Xamarin.FinalCtrl.Sample.ViewModels
{
    public abstract class BaseTabViewModel : BaseViewModel, ITabItem
    {

        public abstract ETabType TabType { get; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }

        public abstract void Appearing();
        public abstract void Disappearing();

    }
}

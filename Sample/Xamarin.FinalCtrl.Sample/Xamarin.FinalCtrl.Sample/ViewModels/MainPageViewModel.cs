using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.FinalCtrl.Helper;
using Xamarin.FinalCtrl.Sample.Enumerations;
using Xamarin.FinalCtrl.Sample.ViewModels.Tabs;
using Xamarin.Forms;

namespace Xamarin.FinalCtrl.Sample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        public ObservableCollection<BaseTabViewModel> Tabs { get; private set; }

        private BaseTabViewModel _selectedTab;
        public BaseTabViewModel SelectedTab
        {
            get => _selectedTab;
            set => Set(ref _selectedTab, value);
        }

        public ICommand SelectSettingsCommand { get; private set; }

        public MainPageViewModel()
        {
            Tabs = new ObservableCollection<BaseTabViewModel>
            {
                new ListTabViewModel(),
                new SettingTabViewModel(),
            };
            SelectedTab = Tabs.First();

            SelectSettingsCommand = new Command(ExecuteSelectSettingsCommand);
        }

        private void ExecuteSelectSettingsCommand()
        {
            SelectedTab = Tabs.Last();
        }


    }
}

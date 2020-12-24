using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.FinalCtrl.Sample.ViewModels.Tabs;
using Xamarin.FinalCtrl.Sample.Views.Tabs;
using Xamarin.Forms;

namespace Xamarin.FinalCtrl.Sample.ContentSelectors
{
    public class MainTabContentSelector : IContentSelector
    {
        public ContentView OnSelectContent(object item)
        {
            return item switch
            {
                ListTabViewModel _ => new ListTabView(),
                SettingTabViewModel _ => new SettingsTabView(),

                _ => throw new NotImplementedException(),
            };
        }
    }
}

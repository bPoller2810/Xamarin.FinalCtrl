using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.FinalCtrl.Sample.Enumerations;

namespace Xamarin.FinalCtrl.Sample.ViewModels.Tabs
{
    public class ListTabViewModel : BaseTabViewModel
    {

        #region BaseTabViewModel
        public override ETabType TabType => ETabType.List;

        public override void Appearing()
        {
        }

        public override void Disappearing()
        {
        }
        #endregion

    }
}

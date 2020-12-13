using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.FinalCtrl.TabViewCtrl
{
    public interface IContentSelector
    {

        ContentView OnSelectContent(object item);

    }
}

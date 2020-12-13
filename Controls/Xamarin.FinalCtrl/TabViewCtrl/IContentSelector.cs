using Xamarin.Forms;

namespace Xamarin.FinalCtrl
{
    public interface IContentSelector
    {

        ContentView OnSelectContent(object item);

    }
}

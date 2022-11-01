using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;

namespace ViewModel
{
    public partial class MainViewModel : ObservableObject
    {

        [ICommand]
        async Task Arranger(string s)
        {
            await Shell.Current.GoToAsync("ArrangerPage");
        }
    }
}
using ViewModel;

namespace AndroidApp;

public partial class ArrangerPage : ContentPage
{
	public ArrangerPage(ArrangerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
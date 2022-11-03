using Microsoft.EntityFrameworkCore.Metadata;
using Services.Interfaces;
using ViewModel;

namespace AndroidApp;

public partial class ArrangerPage : ContentPage
{
	private ArrangerViewModel viewModel;

	public ArrangerPage(ArrangerViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;

		BindingContext = this.viewModel;
    }

	private void Window_Loaded(object sender, EventArgs e)
	{
		viewModel.Initialize();
	}
}
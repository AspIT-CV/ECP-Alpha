using Microsoft.EntityFrameworkCore.Metadata;
using Services.Interfaces;
using ViewModel;

namespace AndroidApp;

public partial class OrganiserPage : ContentPage
{
	private OrganiserViewModel viewModel;

	public OrganiserPage(OrganiserViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;

		BindingContext = this.viewModel;
    }

	private async void Window_Loaded(object sender, EventArgs e)
	{
		await viewModel.Initialize();
	}
}
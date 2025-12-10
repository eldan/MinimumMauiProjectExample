using MinimumMauiProjectExample.ViewModels;

namespace MinimumMauiProjectExample.Views;

public partial class ItemsPage : ContentPage
{
	ItemsPageViewModel vm;
	public ItemsPage() 
	{
        InitializeComponent();

        vm = new ItemsPageViewModel();
        BindingContext = vm;
    }
}
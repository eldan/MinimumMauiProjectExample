using MinimumMauiProjectExample.ViewModels;

namespace MinimumMauiProjectExample.Views;

public partial class RegisterPage : ContentPage
{
    RegisterPageViewModel vm;
    public RegisterPage()
	{
		InitializeComponent();
        vm = new RegisterPageViewModel();
        BindingContext = vm;
    }
}
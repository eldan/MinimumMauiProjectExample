using MinimumMauiProjectExample.ViewModels;

namespace MinimumMauiProjectExample.Views;

public partial class LoginPage : ContentPage
{
  LoginPageViewModel vm;
	public LoginPage()
	{
		InitializeComponent();

    vm = new LoginPageViewModel();
    BindingContext = vm;
  }
}

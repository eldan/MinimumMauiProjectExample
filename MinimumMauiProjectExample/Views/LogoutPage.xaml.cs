using MinimumMauiProjectExample.Services;
using MinimumMauiProjectExample.ViewModels;

namespace MinimumMauiProjectExample.Views;

public partial class LogoutPage : ContentPage
{
	public LogoutPage()
	{
		InitializeComponent();
        InitializeAsync();

    }
    private async Task InitializeAsync()
    {var appShell = (AppShell)Application.Current.MainPage;
        bool successedLogin = await AppService.TryLogout();
        ShellViewModel.instance.IsNotLogin = true;
        ShellViewModel.instance.IsLogin = false;
        //
        await Shell.Current.GoToAsync("//LoginPage");
    }

}
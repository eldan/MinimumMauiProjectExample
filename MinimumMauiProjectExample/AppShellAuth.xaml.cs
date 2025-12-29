using MinimumMauiProjectExample.Services;

namespace MinimumMauiProjectExample;

public partial class AppShellAuth : Shell
{
	public AppShellAuth()
	{
		InitializeComponent();
	}

  private async void MenuItem_Logout_Clicked(object sender, EventArgs e)
  {
    AppService.GetInstance().Logout();
    ((App)Application.Current).SetUnauthenticatedShell();
  }
}

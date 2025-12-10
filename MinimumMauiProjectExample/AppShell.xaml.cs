using MinimumMauiProjectExample.Services;
using MinimumMauiProjectExample.ViewModels;

namespace MinimumMauiProjectExample
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            BindingContext = new ShellViewModel();
        }
    }
}

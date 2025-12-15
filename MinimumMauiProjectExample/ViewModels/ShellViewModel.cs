using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MinimumMauiProjectExample.Services;

namespace MinimumMauiProjectExample.ViewModels
{
  class ShellViewModel : ViewModelBase
  {
    static public ShellViewModel? instance { get; set; }

    #region get and set
    private bool isLogin;
    public bool IsLogin
    {
      get { return isLogin; }
      set
      {
        isLogin = value;
        OnPropertyChanged(nameof(IsLogin));
        if (isLogin)
        {
          LogoutText = "Logout";
        }
        else
        {
          LogoutText = "";
        }
      }
    }

    private bool isNotLogin;
    public bool IsNotLogin
    {
      get { return isNotLogin; }
      set
      {
        isNotLogin = value;
        OnPropertyChanged(nameof(IsNotLogin));
      }
    }

    private string logoutText;
    public string LogoutText
    {
      get { return logoutText; }
      set
      {
        logoutText = value;
        OnPropertyChanged();
      }
    }
    #endregion

    #region Commands
    public ICommand LogoutCommand { get; }
    #endregion

    public ShellViewModel()
    {
      instance = this;
      isLogin = false;
      isNotLogin = true;
      LogoutCommand = new Command(async () => await Logout());
    }

    #region Methods/Functions
    private async Task Logout()
    {
      if (IsLogin)
      {
        bool successed = await AppService.GetInstance().TryLogout();
        if (successed)
        {
          IsLogin = false;
          IsNotLogin = true;
        }
      }

    }
    #endregion
  }
}

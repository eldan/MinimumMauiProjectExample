using MinimumMauiProjectExample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MinimumMauiProjectExample.ViewModels
{
    class LoginPageViewModel : ViewModelBase
    {
        #region Getters & Setters
        private string emailInput;
        public string EmailInput
        {
            get { return emailInput; }
            set { emailInput = value; }
        }

        private string passwordInput;
        public string PasswordInput
        {
            get { return passwordInput; }
            set { passwordInput = value; }
        }
        #endregion

        #region Commands Declaration
        public ICommand SubmitLoginCommand { get; set; }
        public ICommand GoRegisterCommand { get; set; }
        #endregion

        #region Constructor
        public LoginPageViewModel()
        {
            EmailInput = "haha@hoho.com";
            SubmitLoginCommand = new Command(async () => await Login());
            GoRegisterCommand = new Command(async () => await Shell.Current.GoToAsync("//RegisterPage"));
        }
        #endregion

        #region Methods / Functions
        private async Task Login()
        {
            bool successed = await AppService.GetInstance().TryLogin(emailInput, passwordInput);
            if (successed)
            {
                await Shell.Current.GoToAsync("//ItemsPage");
            }
        }
        #endregion
    }
}

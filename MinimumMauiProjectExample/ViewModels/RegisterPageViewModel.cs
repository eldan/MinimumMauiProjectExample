using MinimumMauiProjectExample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MinimumMauiProjectExample.ViewModels
{
    class RegisterPageViewModel : ViewModelBase
    {
        #region Getters & Setters
        private string emailInput;
        public string EmailInput
        {
            get { return emailInput; }
            set { emailInput = value; }
        }

        private string passwordInput1;
        public string PasswordInput1
        {
            get { return passwordInput1; }
            set { passwordInput1 = value; }
        }

        private string passwordInput2;
        public string PasswordInput2
        {
            get { return passwordInput2; }
            set
            {
                passwordInput2 = value;
                if (passwordInput1!="" && passwordInput1 == passwordInput2)
                {
                    IsRegisterButtonEnabled = true;
                }
                else
                {
                    IsRegisterButtonEnabled = false;
                }

            }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private bool isRegisterButtonEnabled;
        public bool IsRegisterButtonEnabled
        {
            get { return isRegisterButtonEnabled; }
            set
            {
                isRegisterButtonEnabled = value;
                OnPropertyChanged(nameof(IsRegisterButtonEnabled));
            }
        }

        #endregion

        #region Commands Declaration
        public ICommand SubmitRegisterCommand { get; set; }
        public ICommand GoLoginCommand { get; set; }
        #endregion

        #region Constuctor
        public RegisterPageViewModel()
        {
            SubmitRegisterCommand = new Command(async () => await Register());
            GoLoginCommand = new Command(async () => await Shell.Current.GoToAsync("//LoginPage"));
        }
        #endregion

        #region Methods / Functions
        private async Task Register()
        {
            bool successed = await AppService.GetInstance().TryRegister(EmailInput, PasswordInput1, FullName);
            if (successed)
            {
                ((App)Application.Current).SetAuthenticatedShell();
                await Shell.Current.GoToAsync("//ItemsPage");
            }
        }
        #endregion
    }
}

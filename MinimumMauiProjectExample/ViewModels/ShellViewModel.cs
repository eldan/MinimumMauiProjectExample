using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MinimumMauiProjectExample.ViewModels
{
    class ShellViewModel : ViewModelBase
    {
        static public ShellViewModel? instance { get; set; }

        public ShellViewModel() {
            
            instance = this;
            isLogin = false;
            isNotLogin = true;
        }

        private bool isLogin;

		public bool IsLogin
		{
			get { return isLogin; }
			set {
				isLogin = value;
                OnPropertyChanged(nameof(IsLogin));
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
    }
}

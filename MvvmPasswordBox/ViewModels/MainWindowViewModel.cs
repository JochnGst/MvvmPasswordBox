using Prism.Mvvm;
using System.Security;
using MvvmPasswordBox.Extentions;

namespace MvvmPasswordBox.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private SecureString _securePassword;
        public SecureString SecurePassword
        {
            get { return _securePassword; }
            set 
            { 
                SetProperty(ref _securePassword, value);
                PlainPassword = _securePassword.ConvertToString();
            }
        }

        private string _plainPassword;
        public string PlainPassword
        {
            get { return _plainPassword; }
            set { SetProperty(ref _plainPassword, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}

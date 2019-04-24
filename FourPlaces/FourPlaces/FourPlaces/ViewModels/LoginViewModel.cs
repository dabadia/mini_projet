﻿using FourPlaces.Views;
using Storm.Mvvm;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FourPlaces.ViewModels
{
    // connexion
    public class LoginViewModel : ViewModelBase
    {
        private string _msg = "";
        private string _email = "";
        private string _password = "";
        public ICommand LoginCommand { protected set; get; }
        public ICommand NavigateToRegisterCommand { protected set; get; }
        public INavigation Navigation { get; set; }

        public string Msg
        {
            get => _msg;
            set => SetProperty(ref _msg, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            LoginCommand = new Command(async () => { await LoginAsync(); });
            NavigateToRegisterCommand = new Command(async () => { await NavigateToRegisterAsync(); });

        }

        public async Task LoginAsync()
        {
            if (Email != "" && Password != "")
            {
                bool res = await App.SERVICE.Authentification(Email, Password);
                if (res)
                {
                    Application.Current.MainPage = new RootPage();

                }
                else
                {
                    Password = "";
                    Msg = "Erreur lors  de votre connection";
                }
            }
            else
            {
                Password = "";
                Msg = "Champs incorrect ! Ve";
            }
            return;
        }

        public async Task NavigateToRegisterAsync()
        {
            Application.Current.MainPage = new RegisterPage();
            return;
        }
    }
    
}

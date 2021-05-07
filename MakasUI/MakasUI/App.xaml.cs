using MakasUI.Views;
using MakasUI.Views.SaloonPages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI
{
    public partial class App : Application
    {
        public const string API_URL = "https://192.168.0.38:45455/api/";
        public const string tokenKey = "token";
        public const string loggedInKey = "loggedIn";
        public const string userId = "userId";
        public const string userName = "userName";
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] {
                "Expander_Experimental"
            });

            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart()
        {
            MainPage = new NavigationPage(new WelcomePage());
            /*if (LoggedIn == "false")
                MainPage = new NavigationPage(new WelcomePage());

            if (LoggedIn == "true")
                MainPage = new SaloonHomePage();*/
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public string TOKEN
        {
            get
            {
                if (Properties.ContainsKey(tokenKey))
                {
                    SavePropertiesAsync();
                    return Properties[tokenKey].ToString();
                }

                return "";
            }
            set
            {
                Properties[tokenKey] = value;
            }
        }
        public string USER_ID
        {
            get
            {
                if (Properties.ContainsKey(userId))
                {
                    SavePropertiesAsync();
                    return Properties[userId].ToString();
                }

                return "";
            }
            set
            {
                Properties[userId] = value;
            }
        }
        public string USER_NAME
        {
            get
            {
                if (Properties.ContainsKey(userName))
                {
                    SavePropertiesAsync();
                    return Properties[userName].ToString();
                }

                return "";
            }
            set
            {
                Properties[userName] = value;
            }
        }

        public string LoggedIn
        {
            get
            {
                if (Properties.ContainsKey(loggedInKey))
                {
                    SavePropertiesAsync();
                    return Properties[loggedInKey].ToString();
                }

                return "";
            }
            set
            {
                Properties[loggedInKey] = value;
            }
        }
    }
}

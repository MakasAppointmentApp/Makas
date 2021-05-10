using MakasUI.Services;
using MakasUI.Services.CustomerManagers;
using MakasUI.Services.CustomerServices.Concrete;
using MakasUI.Services.SaloonManagers;
using MakasUI.Services.SaloonServices;
using MakasUI.Views;
using MakasUI.Views.SaloonPages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI
{
    public partial class App : Application
    {
        public const string API_URL = "https://192.168.1.21:45455/api/";
        public const string tokenKey = "token";
        public const string loggedInKey = "loggedIn";
        public const string userId = "userId";
        public const string userName = "userName";

        public static SaloonManager saloonManager { get; private set; }
        public static SaloonAuthManager saloonAuthManager { get; private set; }
        public static CustomerManager customerManager { get; private set; }
        public static CustomerAuthManager customerAuthManager { get; private set; }

        public App()
        {
            InitializeComponent();
            saloonManager = new SaloonManager(new SaloonRestService());
            saloonAuthManager = new SaloonAuthManager(new SaloonAuthServices());
            customerManager = new CustomerManager(new CustomerRestService());
            customerAuthManager = new CustomerAuthManager(new CustomerAuthService());
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

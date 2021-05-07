using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.SaloonPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaloonHomePage : Shell
    {
        public SaloonHomePage()
        {
            InitializeComponent();


        }


        private void Logout_Clicked(object sender, EventArgs e)
        {
            // Alert Yes No
            var app = Application.Current as App;
            app.USER_ID = "";
            app.LoggedIn = "false";
            app.TOKEN = "";
            app.USER_NAME = "";
            App.Current.MainPage = new NavigationPage(new WelcomePage());

        }

    }
}
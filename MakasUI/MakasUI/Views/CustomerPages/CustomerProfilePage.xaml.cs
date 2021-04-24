using MakasUI.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerProfilePage : ContentPage
    {
        public CustomerProfilePage()
        {
            InitializeComponent();
           
        }

        private void ExitClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new WelcomePage());

        }

        public void ShowPass(object sender, EventArgs args)
        {
            Password.IsPassword = Password.IsPassword ? false : true;
            EyeVisible.Source = Password.IsPassword ? "eye.png" : "closedeye.png";            
            
        }
       
      

     
    }
}
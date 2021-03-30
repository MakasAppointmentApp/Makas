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
        

        private void ExitClicked(object sender, EventArgs e)
        {
                App.Current.MainPage = new NavigationPage(new WelcomePage());
        }
    }
}
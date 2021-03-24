using MakasUI.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCustomerPage : ContentPage
    {
        public RegisterCustomerPage()
        {
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
        }
        public void ShowPass(object sender, EventArgs args)
        {
            Password.IsPassword = Password.IsPassword ? false : true;
            EyeVisible.Source = Password.IsPassword ? "eye.png" : "closedeye.png";
        }
    }
}
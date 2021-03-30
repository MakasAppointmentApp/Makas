using MakasUI.Functions;
using MakasUI.Models;
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
    public partial class EditSaloonPage : ContentPage
    {
        public EditSaloonPage()
        {
            InitializeComponent();
            

            ItemFunctions function = new ItemFunctions();
            function.backclick(back, Navigation);
        }
        public EditSaloonPage(string text, ImageSource profilePhoto, string saloonLocation)
        {
            InitializeComponent();
            this.saloonName.Text = text;
            this.sPhoto.Source = profilePhoto;
            this.locName.Text = saloonLocation;

            ItemFunctions function = new ItemFunctions();
            function.backclick(back,Navigation);
        }

      

        public void ShowPass(object sender, EventArgs args)
        {
            Password.IsPassword = Password.IsPassword ? false : true;
            EyeVisible.Source = Password.IsPassword ? "eye.png" : "closedeye.png";
        }

    }
}
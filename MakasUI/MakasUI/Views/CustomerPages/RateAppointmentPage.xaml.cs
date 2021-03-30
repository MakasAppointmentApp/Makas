using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakasUI.Functions;
using Syncfusion.SfRating.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RateAppointmentPage : ContentPage
    {
        public RateAppointmentPage()
        {
            
            InitializeComponent();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back,Navigation);
        }

        private void rating_ValueChanged(object sender, ValueEventArgs e)
        {

            RateLabel.Text = rating.Value.ToString();
        }
    }
}
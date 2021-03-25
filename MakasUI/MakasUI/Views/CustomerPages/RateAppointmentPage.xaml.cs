using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void rating_ValueChanged(object sender, ValueEventArgs e)
        {

            RateLabel.Text = rating.Value.ToString();
        }
    }
}
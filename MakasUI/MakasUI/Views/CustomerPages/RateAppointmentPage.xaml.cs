using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakasUI.Functions;
using MakasUI.Models.DtosForCustomer;
using Syncfusion.SfRating.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RateAppointmentPage : ContentPage
    {
        private ReviewDto ob;

        public RateAppointmentPage(ReviewDto ob)
        {
            this.ob = ob;
            InitializeComponent();
            sName.Text = ob.SaloonName;
            wName.Text = ob.WorkerName;
            sRate.Text = ob.SaloonRate.ToString();
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
        }

        private void rating_ValueChanged(object sender, ValueEventArgs e)
        {

            RateLabel.Text = rating.Value.ToString();
        }
    }
}
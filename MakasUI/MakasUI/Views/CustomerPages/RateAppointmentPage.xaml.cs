using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakasUI.Functions;
using MakasUI.Helpers.Validations.CustomerValidations.CustomerRateValidations;
using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using Syncfusion.SfRating.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MakasUI.Views.CustomerPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RateAppointmentPage : ContentPage
    {
        private CustomerAppointmentsDto ob;

        public RateAppointmentPage(CustomerAppointmentsDto ob)
        {
            this.ob = ob;
            InitializeComponent();
            sName.Text = ob.SaloonName;
            wName.Text = ob.WorkerName;
            sRate.Text = ob.SaloonRate.ToString("0.##");
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
        }

        private void rating_ValueChanged(object sender, ValueEventArgs e)
        {

            RateLabel.Text = rating.Value.ToString();
        }

        CustomerRateValidator customerRateValidator = new CustomerRateValidator();
        CustomerCommentValidator customerCommentValidator = new CustomerCommentValidator();
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string customerRateValidate = customerRateValidator.Validate(RateLabel.Text);
            string customerCommentValidate = customerCommentValidator.Validate(commentLabel.Text);

            if (customerRateValidate == null && customerCommentValidate == null)
            {
                var app = Application.Current as App;

                var response = await App.customerManager.AddReviewAsync(
                    new AddReviewDto
                    {
                        AppointmentId = ob.AppointmentId,
                        CustomerId = Convert.ToInt32(app.USER_ID),
                        SaloonId = ob.SaloonId,
                        WorkerId = ob.WorkerId,
                        Date = DateTime.Now,
                        Rate = Convert.ToDouble(RateLabel.Text),
                        Comment = commentLabel.Text,
                    });
                if (response.IsSuccessStatusCode.Equals(true))
                {
                    await DisplayAlert("Başarılı", "Yorumunuz başarıyla eklendi", "Tamam");
                    App.Current.MainPage = new CustomerHomePage();
                }
            }
            else
            {
                customerRateErrorLabel.Text = customerRateValidate;
                customerCommentErrorLabel.Text = customerCommentValidate;
            }

        }
    }
}
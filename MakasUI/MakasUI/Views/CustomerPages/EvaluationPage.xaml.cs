using MakasUI.Functions;
using MakasUI.Models.DtosForCustomer;
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
    public partial class EvaluationPage : ContentPage
    {
        private int _Id;
        public EvaluationPage(CustomerAppointmentsDto ob)
        {
            InitializeComponent();                     
            ItemFunctions functions = new ItemFunctions();
            functions.backclick(back, Navigation);
            _Id= ob.Id;

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var result = await App.customerManager.GetReviewAsync(_Id);
            sRate.Text = result.Rate.ToString();
            commentLabel.Text = result.Comment;
        }

    }
}